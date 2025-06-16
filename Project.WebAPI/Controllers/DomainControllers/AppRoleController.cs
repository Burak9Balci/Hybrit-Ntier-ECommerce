using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.BusinessLogicLayer.DTOClasses;
using Project.BusinessLogicLayer.Managers.Abstracts;
using Project.BusinessLogicLayer.Managers.Concretes;
using Project.Entities.Models.Domains;
using Project.WebAPI.Models.RequestModels.AppRole;
using Project.WebAPI.Models.ResponseModels.AppRole;

namespace Project.WebAPI.Controllers.DomainControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppRoleController : ControllerBase
    {
        IMapper _mapper;
        IAppRoleManager _appRoleManager;
        public AppRoleController(IMapper mapper,IAppRoleManager appRoleManager)
        {
            _appRoleManager = appRoleManager;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetRoles()
        {
            List<AppRoleResponseModel> roles = _mapper.Map<List<AppRoleResponseModel>>(_appRoleManager.GetActives());
            return Ok(roles);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRole(int id)
        { 
            AppRoleResponseModel appRole = _mapper.Map<AppRoleResponseModel>(await _appRoleManager.FindAsync(id));
            return Ok(appRole);
        }
        [HttpPost]
        public async Task<IActionResult> AddRole(CreateAppRoleRequestModel createAppRole)
        {
            await _appRoleManager.AddAsync(_mapper.Map<AppRoleDTO>(createAppRole));
            return Ok("Ekleme yapıldı");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRole(int id,UpdateAppRoleRequestModel updateAppRole)
        {
            if (id != updateAppRole.Id) return BadRequest("gönderilen idler uyuşmuyor"); 
            await _appRoleManager.UpdateAsync(_mapper.Map<AppRoleDTO>(updateAppRole));
            return Ok("güncelleme yapıldı");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            await _appRoleManager.DeleteAsync(id);
            return Ok("Silindi");
        }
    }
}
