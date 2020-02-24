using ManualShitShop2.Areas.Identity.Data;
using ManualShitShop2.Models;
using ManualShitShop2.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
        private readonly ApplicationDbContext _db;
        public AdminService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _db = db;
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

        public async Task<CreateUserViewModel> GetUser(string id)
        {
            var user = await _db.Users.FindAsync(id);
            var role = await _userManager.GetRolesAsync(user);
            var usertoreturn = new CreateUserViewModel { Birthdate = user.Birthdate, Email = user.Email, Role = role[0] };
            return usertoreturn;
        }

        public async Task<List<ApplicationUser>> GetUsers()
        {
            var users = await _db.Users.ToListAsync();
            return users;
        }
    }
}
