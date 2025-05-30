using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Project.BusinessLogicLayer.DTOClasses;
using Project.BusinessLogicLayer.MailServices;
using Project.BusinessLogicLayer.Managers.Abstracts;
using Project.DataAccessLayer.Repositories.Abstracts;
using Project.Entities.Models.Domains;
using Project.Entities.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BusinessLogicLayer.Managers.Concretes
{
    public class AppUserManager : BaseManager<AppUserDTO, AppUser>, IAppUserManager
    {
        readonly IMapper _mapper;
        readonly IRepository<AppUser> _repository;
        readonly UserManager<AppUser> _userManager;
        readonly RoleManager<AppRole> _roleManager;
        readonly SignInManager<AppUser> _signManager;
        public AppUserManager(IMapper mapper, IRepository<AppUser> repository, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager,SignInManager<AppUser> signInManager) : base(mapper, repository)
        {
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
            _signManager = signInManager;
            _repository = repository;
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
            return await _signManager.PasswordSignInAsync(await FindUserByEmailAsync(appUserDTO), appUserDTO.Password, true, true);
        }

        public async Task SendConfirmEMailAsync(string email)
        {
            AppUser appUser = await _userManager.FindByEmailAsync(email);
            MailService.Send(receiver:email,body: $"Hesabınız olusturulmustur...Üyeliginizi onaylamak icin lütfen http://localhost:5110/Authentication/ConfirmEmail?specId={appUser.ActivationCode}&id={appUser.Id} linkine tıklayınız ");
        }



        public async Task<ConfirmEmailResultDTO> ConfirmEmailAsync(Guid specId, int id)
        {
            ConfirmEmailResultDTO result = new();
            AppUser appUser = await _repository.FindAsync(id);

            if (appUser == null)
            {
                result.Succeeded = false;
                result.Message = "kullanıcı bulunamadı";
                return result;
            }
            else if (appUser.EmailConfirmed)
            {
                result.Succeeded = false;
                result.Message = "e posta zaten onaylanmış";
                return result;
            }
            else if (appUser.ActivationCode != specId)
            {
                result.Succeeded = false;
                result.Message = "aktivasyon kodu geçersiz";
                return result;
            }

            appUser.EmailConfirmed = true;
            appUser.ModifiedDate = DateTime.Now;
            appUser.Status = DataStatus.Updated;
            await _repository.SaveChangesAsync();

            result.Succeeded = true;
            result.Message = "e posta onaylandı";
            return result;
        }



    }
}
