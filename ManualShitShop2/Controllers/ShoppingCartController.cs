using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManualShitShop2.Areas.Identity.Data;
using ManualShitShop2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ManualShitShop2.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartService _shoppingCartService;
        private readonly UserManager<ApplicationUser> _userManager;
        public ShoppingCartController(IShoppingCartService shoppingCartService, UserManager<ApplicationUser> userManager)
        {
            _shoppingCartService = shoppingCartService;
            _userManager = userManager;
        }
        public async Task<IActionResult> IndexAsync()
        {
            var cart = await _shoppingCartService.GetItems();
            return View(cart);
        }
        public async Task<IActionResult> AddToCartAsync(int id, IFormCollection collection)
        {
            int amount = Convert.ToInt32(collection["Amount"]);
            var claim = HttpContext.User;
            await _shoppingCartService.AddToCart(id, claim, amount);
            return RedirectToAction("Details", "Product", new { id });
        }
        public async Task<IActionResult> RemoveFromCartAsync(int id)
        {
            await _shoppingCartService.RemoveFromCart(id);
            return View("Index");
        }
        public async Task<IActionResult> BuyAsync(int amount)
        {
            var claim = HttpContext.User;
            await _shoppingCartService.BuyAllAsync(claim, amount);
            await _shoppingCartService.ClearCart(claim);
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _shoppingCartService.RemoveFromCart(id);
            var items = await _shoppingCartService.GetItems();
            return View("IndexAsync", items);
        }
    }
}