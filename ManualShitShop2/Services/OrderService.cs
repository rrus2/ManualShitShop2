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

        public async Task Buy(int id, ClaimsPrincipal claim)
        {
            var user = await _userManager.GetUserAsync(claim);
            _db.Orders.Add(new Order { ApplicationUserID = user.Id, ProductID = id });
            _db.SaveChanges();
        }
    }
}
