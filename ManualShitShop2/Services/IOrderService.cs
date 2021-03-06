﻿using ManualShitShop2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ManualShitShop2.Services
{
    public interface IOrderService
    {
        Task BuyAsync(int id, ClaimsPrincipal user, int amount);
        Task<List<Order>> GetAll();
    }
}
