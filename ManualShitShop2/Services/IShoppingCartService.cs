using ManualShitShop2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ManualShitShop2.Services
{
    public interface IShoppingCartService
    {
        Task<List<ShoppingCart>> GetItems();
        Task AddToCart(int id, ClaimsPrincipal claim, int amount);
        Task RemoveFromCart(int id);
        Task BuyAllAsync(ClaimsPrincipal claim, int amount);
        Task ClearCart(ClaimsPrincipal claim);
    }
}
