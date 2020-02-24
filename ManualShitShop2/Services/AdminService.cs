using ManualShitShop2.Areas.Identity.Data;
using ManualShitShop2.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManualShitShop2.Services
{
    public class AdminService : IAdminService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AdminService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task CreateUser(CreateUserViewModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("Model cannot be null");
            }
            var user = new ApplicationUser { Email = model.Email, UserName = model.Email, Birthdate = model.Birthdate };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                throw new Exception("Fail creating new user");
            }
            await _userManager.AddToRoleAsync(user, model.Role);
        }
    }
}
