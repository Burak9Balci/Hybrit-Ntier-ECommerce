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
    public class AppUserManager : BaseManager<AppUserDTO, User>, IAppUserManager
    {
        readonly IMapper _mapper;
        readonly IRepository<User> _repository;
        readonly UserManager<User> _userManager;
        readonly RoleManager<Role> _roleManager;
        readonly SignInManager<User> _signManager;
        public AppUserManager(IMapper mapper, IRepository<User> repository, UserManager<User> userManager, RoleManager<Role> roleManager,SignInManager<User> signInManager) : base(mapper, repository)
        {
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
            _signManager = signInManager;
            _repository = repository;
        }

        public async Task AddToRoleAsync(AppUserDTO appUser)
        {
         
            Role appRole = await _roleManager.FindByNameAsync("Member");
            User appUserDomain = await _userManager.FindByEmailAsync(appUser.Email);
            await _userManager.AddToRoleAsync(appUserDomain, appRole.Name);
        }


        public async Task<IdentityResult> CreateAppUserAsync(AppUserDTO appUserDTO)
        {
            Guid specId = Guid.NewGuid();
            User user = _mapper.Map<User>(appUserDTO);
            user.CreatedDate = DateTime.Now;
            user.Status = DataStatus.Inserted;
            user.ActivationCode = specId;
            return await _userManager.CreateAsync(user, appUserDTO.Password);

        }


        public async Task<User> FindUserByEmailAsync(AppUserDTO appUserDTO)
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
            User appUser = await _userManager.FindByEmailAsync(email);
            MailService.Send(receiver:email,body: $"Hesabınız olusturulmustur...Üyeliginizi onaylamak icin lütfen http://localhost:5110/api/authentication?specId={appUser.ActivationCode}&id={appUser.Id} linkine tıklayınız ");
        }



        public async Task<ConfirmEmailResultDTO> ConfirmEmailAsync(Guid specId, int id)
        {
            ConfirmEmailResultDTO result = new();
            User appUser = await _repository.FindAsync(id);

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

        public async Task UpdateUserRole(string role, int id)
        {
            User user =  await _repository.FindAsync(id);
            await _userManager.AddToRoleAsync(user, role);
            user.Status = DataStatus.Updated;
            user.ModifiedDate = DateTime.Now;
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteRoleFromUser(string role, int id)
        {
            User appUser = await _repository.FindAsync(id);
            await _userManager.RemoveFromRoleAsync(appUser, role);
            appUser.Status = DataStatus.Updated;
            appUser.ModifiedDate = DateTime.Now;
            await _repository.SaveChangesAsync();
        }

        public async Task<List<AppUserDTO>> GetAllUsersWithRolesAsync()
        {
            List<User> activeUsers = _repository.Where(x =>x.Status != DataStatus.Deleted);
            List<AppUserDTO> userDtos = new List<AppUserDTO>();

            foreach (User user in activeUsers)
            {
                AppUserDTO dto = _mapper.Map<AppUserDTO>(user);
                IList<string> roles = await _userManager.GetRolesAsync(user);
                dto.Roles = roles.ToList();
                userDtos.Add(dto);
            }

            return userDtos;
        }

    }
}
