using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManualShitShop2.Areas.Identity.Data;
using ManualShitShop2.Models;
using ManualShitShop2.Services;
using ManualShitShop2.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ManualShitShop2.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        private readonly IProductService _productService;
        public AdminController(IAdminService adminService, IProductService productService)
        {
            _adminService = adminService;
            _productService = productService;
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
        [ValidateAntiForgeryToken]
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
        public async Task<IActionResult> EditUser()
        {
            var users = await _adminService.GetUsers();
            LoadUsers(users);
            return View();
        }
        public async Task<IActionResult> EditUserDetails(string id)
        {
            var user = await _adminService.GetUser(id);
            CreateRoles();
            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUserDetailsPage(CreateUserViewModel model, string id)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await _adminService.EditUser(id, model);
            return View("ThankYouEditUser");
        }
        public async Task<IActionResult> DeleteUser()
        {
            var users = await _adminService.GetUsers();
            LoadUsers(users);
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DeleteUser(string id)
        {
            await _adminService.DeleteUser(id);
            return View("ThankYouDeleteUser");
        }
        public async Task<IActionResult> UpdateProduct()
        {
            var products = await _productService.GetProductsAsync(null, null, null);
            LoadProducts(products);
            return View();
        }
        public IActionResult ThankYouDeleteUser()
        {
            return View();
        }
        public IActionResult ThankYouEditUser()
        {
            return View();
        }
        public IActionResult ThankYouUser()
        {
            return View();
        }
        public IActionResult ThankYouProduct()
        {
            return View();
        }
        private void CreateRoles()
        {
            List<string> roles = new List<string> { "Admin", "User" };
            var select = new SelectList(roles);
            ViewBag.Roles = select;
        }
        private void LoadUsers(List<ApplicationUser> users)
        {
            var list = new SelectList(users, "Id", "Email");
            ViewBag.Users = list;
        }
        private void LoadProducts(List<Product> products)
        {
            var list = new SelectList(products, "ProductID", "Name");
            ViewBag.Products = list;
        }
    }
}