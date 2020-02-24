using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManualShitShop2.Areas.Identity.Data;
using ManualShitShop2.Services;
using ManualShitShop2.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ManualShitShop2.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }
        public async Task<IActionResult> CreateUser()
        {
            CreateRoles();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserViewModel user)
        {
            if (!ModelState.IsValid)
            {
                CreateRoles();
                return View(user);
            }
            await _adminService.CreateUser(user);
            return View("ThankYouUser");
        }
        public IActionResult ThankYouUser()
        {
            return View();
        }
        public IActionResult ThankYouProduct()
        {
            return View();
        }
        public void CreateRoles()
        {
            List<string> roles = new List<string> { "Admin", "User" };
            var select = new SelectList(roles);
            ViewBag.Roles = select;
        }
    }
}