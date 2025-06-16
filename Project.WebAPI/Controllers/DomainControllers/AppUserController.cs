using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.BusinessLogicLayer.DTOClasses;
using Project.BusinessLogicLayer.Managers.Abstracts;
using Project.WebAPI.Models.RequestModels.AppUser;
using Project.WebAPI.Models.ResponseModels.AppUserResponseModels;

namespace Project.WebAPI.Controllers.DomainControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        IMapper _mapper;
        IAppUserManager _userManager;
        public AppUserController(IMapper mapper,IAppUserManager userManager)
        {
            _mapper = mapper;   
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult GetUsers()
        {
            List<AppUserResponseModel> appUsers = _mapper.Map<List<AppUserResponseModel>>(_userManager.GetActives());
            return Ok(appUsers);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
           AppUserResponseModel user = _mapper.Map<AppUserResponseModel>(await _userManager.FindAsync(id));
           return Ok(user);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id,UpdateUserRequestModel requestModel)
        {
            if (id != requestModel.Id) return BadRequest("gönderilen idler uyuşmuyor");
            await _userManager.UpdateAsync(_mapper.Map<AppUserDTO>(requestModel));
            return Ok("Güncellendi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userManager.DeleteAsync(id);
            return Ok("User Askıya alındı");
        }
    }
}
