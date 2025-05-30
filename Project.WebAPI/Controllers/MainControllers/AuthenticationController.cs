using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.BusinessLogicLayer.DTOClasses;
using Project.BusinessLogicLayer.Managers.Abstracts;
using Project.BusinessLogicLayer.Managers.Concretes;
using Project.Entities.Models.Domains;
using Project.WebAPI.Models.RequestModels;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace Project.WebAPI.Controllers.MainControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {

        readonly IAppUserManager _appUserManager;
        readonly IMapper _mapper;
        public AuthenticationController(IAppUserManager appUserManager,IMapper mapper)
        {
            _appUserManager = appUserManager;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(Guid specId,int id) 
        {

            ConfirmEmailResultDTO confirm = await _appUserManager.ConfirmEmailAsync(specId,id);
            if(confirm.Succeeded) return Ok($"{confirm.Message}");
            else return BadRequest($"{confirm.Message}");

        }
        [HttpPost]
        public async Task<IActionResult> Register(UserRequestModel requestModel)
        {

            if (await _appUserManager.AnyAsync(x =>x.Email == requestModel.Email))
            {
                AppUserDTO appUserDTO = _mapper.Map<AppUserDTO>(requestModel);
                IdentityResult result = await _appUserManager.CreateAppUserAsync(appUserDTO);

                if (result.Succeeded)
                {
                    await _appUserManager.AddToRoleAsync(appUserDTO);
                    await _appUserManager.SendConfirmEMailAsync(appUserDTO.Email);
                    Ok("Kayıt oldun Evladımm");
                }
                return BadRequest("Giriş Yaparken Hata");
            }
            return BadRequest("Girdiğin Email daha onceden alınmış");
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(UserRequestModel requestModel)
        {
            AppUserDTO appUserDTO = _mapper.Map<AppUserDTO>(requestModel);
            SignInResult result = await _appUserManager.PasswordSignInAsync(appUserDTO);

            if (result.Succeeded)
            {
                IList<string> roles = await _appUserManager.GetRolesAsync(appUserDTO);
                if (roles.Contains("Admin"))
                {
                    return Ok(new { Message = "Admin girişi başarılı", Role = "Admin" });
                }
                else if (roles.Contains("Member"))
                {
                    return Ok(new { Message = "Üye girişi başarılı", Role = "Member" });
                }

            }
            else if (result.IsNotAllowed)
            {
                return Unauthorized(new { Message = "Mail onayı gerekiyor" });
            }

            return BadRequest(new { Message = "Giriş başarısız, kullanıcı adı veya şifre hatalı" });
        }

    }
}
