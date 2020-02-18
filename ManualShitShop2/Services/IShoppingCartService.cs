using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ManualShitShop2.Services
{
    public interface IShoppingCartService
    {
        Task AddToCart(int id, ClaimsPrincipal claim);
        Task RemoveFromCart(int id, ClaimsPrincipal claim);
    }
}
