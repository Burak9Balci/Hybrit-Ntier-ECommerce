using Microsoft.AspNetCore.Identity;
using Project.BusinessLogicLayer.DTOClasses;
using Project.Entities.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BusinessLogicLayer.Managers.Abstracts
{
    public interface IAppUserManager : IManager<AppUserDTO,AppUser>
    {
        public Task<IdentityResult> CreateAppUserAsync(AppUserDTO appUserDTO);
        public Task AddToRoleAsync(AppUserDTO appUserDTO);
        public Task<SignInResult> PasswordSignInAsync(AppUserDTO appUserDTO);
        public Task<AppUser> FindUserByEmailAsync(AppUserDTO appUserDTO);
        public Task<IList<string>> GetRolesAsync(AppUserDTO appUserDTO);
        public Task SendConfirmEMail(string email);
    }
}
