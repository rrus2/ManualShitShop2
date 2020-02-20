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

        public async Task BuyAsync(int id, ClaimsPrincipal claim, int amount)
        {
            // find user
            var user = await _userManager.GetUserAsync(claim);
            //find product
            var product = _db.Products.Find(id);
            // find order
            var order = _db.Orders.FirstOrDefault(x => x.Product == product && x.ApplicationUser == user);
            if (order != null)
            {
                order.Amount += amount;
            }
            else
            {
                _db.Orders.Add(new Order { ApplicationUser = user, Product = product, Amount = amount });
            }
            product.Stock -= amount;
            await _db.SaveChangesAsync();
        }

        public async Task<List<Order>> GetAll()
        {
            var orders = _db.Orders.ToList();
            return orders;
        }
    }
}
