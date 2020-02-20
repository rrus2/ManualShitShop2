using ManualShitShop2.Areas.Identity.Data;
using ManualShitShop2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ManualShitShop2.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IOrderService _orderService;
        public ShoppingCartService(ApplicationDbContext db, UserManager<ApplicationUser> userManager, IOrderService orderService)
        {
            _db = db;
            _userManager = userManager;
            _orderService = orderService;
        }
        public async Task AddToCart(int id, ClaimsPrincipal claim, int amount)
        {
            var user = await _userManager.GetUserAsync(claim);
            var product = _db.Products.FirstOrDefault(x => x.ProductID == id);
            if (product == null)
            {
                throw new Exception("Fail finding product");
            }
            var cart = new ShoppingCart { ApplicationUser = user, Product = product, TotalPrice = product.Price * amount, Amount = amount };
            _db.ShoppingCart.Add(cart);
            await _db.SaveChangesAsync();
        }

        public async Task BuyAllAsync(ClaimsPrincipal claim, int amount)
        {
            var user = await _userManager.GetUserAsync(claim);
            var orders = await _orderService.GetAll();
            var selectedorders = orders.Where(x => x.ApplicationUserID == user.Id);
            foreach (var item in selectedorders)
            {
                await _orderService.BuyAsync((int)item.ProductID, claim, amount);
            }
            await _db.SaveChangesAsync();
        }

        public async Task ClearCart(ClaimsPrincipal claim)
        {
            var user = await _userManager.GetUserAsync(claim);
            var orders = await _orderService.GetAll();
            var shoppingcart = _db.ShoppingCart.Where(x => x.ApplicationUser == user);
            _db.ShoppingCart.RemoveRange(shoppingcart);
            await _db.SaveChangesAsync();
        }

        public async Task<List<ShoppingCart>> GetItems()
        {
            var cart = _db.ShoppingCart.Include(x => x.Product).Include(x => x.ApplicationUser).ToList();
            return cart;
        }

        public async Task RemoveFromCart(int id)
        {
            var cart = _db.ShoppingCart.FirstOrDefault(x => x.Product.ProductID == id);
            if (cart == null)
            {
                throw new Exception("Fail finding product");
            }
            _db.ShoppingCart.Remove(cart);
            await _db.SaveChangesAsync();
        }
    }
}
