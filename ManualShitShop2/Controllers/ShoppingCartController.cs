using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManualShitShop2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManualShitShop2.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartService _shoppingCartService;
        public ShoppingCartController(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
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
    }
}