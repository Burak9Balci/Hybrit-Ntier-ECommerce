﻿using Microsoft.AspNetCore.Identity;
using Project.BusinessLogicLayer.DTOClasses;
using Project.Entities.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BusinessLogicLayer.Managers.Abstracts
{
    public interface IAppUserManager : IManager<AppUserDTO,User>
    {
        Task<IdentityResult> CreateAppUserAsync(AppUserDTO appUserDTO);
        Task AddToRoleAsync(AppUserDTO appUserDTO);
        Task<SignInResult> PasswordSignInAsync(AppUserDTO appUserDTO);
        Task<User> FindUserByEmailAsync(AppUserDTO appUserDTO);
        Task<IList<string>> GetRolesAsync(AppUserDTO appUserDTO);
        Task SendConfirmEMailAsync(string email);
        Task<ConfirmEmailResultDTO> ConfirmEmailAsync(Guid specId, int id);
        Task DeleteRoleFromUser(string role,int id);
        Task UpdateUserRole(string role, int id);
        Task<List<AppUserDTO>> GetAllUsersWithRolesAsync();

    }
}
