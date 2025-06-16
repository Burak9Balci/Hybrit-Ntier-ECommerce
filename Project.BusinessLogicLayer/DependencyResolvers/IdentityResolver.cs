using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Project.DataAccessLayer.ContextClasses;
using Project.Entities.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BusinessLogicLayer.DependencyResolvers
{
    public static class IdentityResolver
    {
        public static void AddIdentityService(this IServiceCollection services)
        {
            services.AddIdentityCore<User>(x =>
            {
                x.Password.RequireDigit = false;
                x.Password.RequiredLength = 3;
                x.Password.RequireLowercase = false;
                x.Password.RequireUppercase = false;
                x.SignIn.RequireConfirmedEmail = true;
                x.Password.RequireNonAlphanumeric = false;
            })
     .AddRoles<Role>() 
     .AddRoleManager<RoleManager<Role>>() 
     .AddSignInManager<SignInManager<User>>() 
     .AddEntityFrameworkStores<MyContext>()
     .AddDefaultTokenProviders();
        }
    }
}
