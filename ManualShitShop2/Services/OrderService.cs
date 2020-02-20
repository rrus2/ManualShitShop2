using ManualShitShop2.Areas.Identity.Data;
using ManualShitShop2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ManualShitShop2.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        public OrderService(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public async Task Buy(int id, ClaimsPrincipal claim, int amount)
        {
            // find user
            var user = await _userManager.GetUserAsync(claim);
            //find product
            var product = _db.Products.Find(id);
            // find order
            var order = _db.Orders.FirstOrDefault(x => x.ProductID == product.ProductID && x.ApplicationUserID == user.Id);
            if (order != null)
            {
                order.Amount += amount;
            }
            else
            {
                _db.Orders.Add(new Order { ApplicationUserID = user.Id, ProductID = id, Amount = amount });
            }
            product.Stock -= amount;
            await _db.SaveChangesAsync();
        }
    }
}
