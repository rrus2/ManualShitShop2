using ManualShitShop2.Areas.Identity.Data;
using ManualShitShop2.Models;
using Microsoft.AspNetCore.Identity;
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
        public ShoppingCartService(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }
        public async Task AddToCart(int id, ClaimsPrincipal claim)
        {
            var user = await _userManager.GetUserAsync(claim);
            var cart = new ShoppingCart { ProductID = id, UserID = user.Id };
            
        }
        public async Task RemoveFromCart(int id, ClaimsPrincipal claim)
        {
            throw new NotImplementedException();
        }
    }
}
