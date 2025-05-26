using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Project.BusinessLogicLayer.DTOClasses;
using Project.BusinessLogicLayer.MailServices;
using Project.BusinessLogicLayer.Managers.Abstracts;
using Project.DataAccessLayer.Repositories.Abstracts;
using Project.Entities.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BusinessLogicLayer.Managers.Concretes
{
    public class AppUserManager : BaseManager<AppUserDTO, AppUser>, IAppUserManager
    {
        IMapper _mapper; 
        UserManager<AppUser> _userManager;
        RoleManager<AppRole> _roleManager;
        SignInManager<AppUser> _signManager;
        public AppUserManager(IMapper mapper, IRepository<AppUser> repository, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager,SignInManager<AppUser> signInManager) : base(mapper, repository)
        {
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
            _signManager = signInManager;
        }

        public async Task AddToRoleAsync(AppUserDTO appUser)
        {
         
            AppRole appRole = await _roleManager.FindByNameAsync("Member");
            if (appRole == null)
            {
                await _roleManager.CreateAsync(new() { Name = "Member"});
            }
            await _userManager.AddToRoleAsync(_mapper.Map<AppUser>(appUser), "Member");
        }

        public async Task<IdentityResult> CreateAppUserAsync(AppUserDTO appUserDTO)
        {
            AppUser user = _mapper.Map<AppUser>(appUserDTO);
            Guid specId = Guid.NewGuid();
            user.ActivationCode = specId;
            return await _userManager.CreateAsync(user,appUserDTO.Password);

        }

        public async Task<AppUser> FindUserByEmailAsync(AppUserDTO appUserDTO)
        {
          return await _userManager.FindByEmailAsync(appUserDTO.Email);
        }

        public async Task<IList<string>> GetRolesAsync(AppUserDTO appUserDTO)
        {
            return await _userManager.GetRolesAsync(await FindUserByEmailAsync(appUserDTO));
        }

        public async Task<SignInResult> PasswordSignInAsync(AppUserDTO appUserDTO)
        {
            return await _signManager.PasswordSignInAsync(await FindUserByEmailAsync(appUserDTO), appUserDTO.Password,true,true);
        }

        public async Task SendConfirmEMail(string email)
        {
            AppUser appUser = await _userManager.FindByEmailAsync(email);
            MailService.Send(receiver:email,body: $"Hesabınız olusturulmustur...Üyeliginizi onaylamak icin lütfen http://localhost:5172/Home/ConfirmEmail?specId={appUser.ActivationCode}&id={appUser.Id} linkine tıklayınız ");
        }
    }
}
