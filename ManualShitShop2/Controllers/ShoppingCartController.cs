using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ManualShitShop2.Controllers
{
    public class ShoppingCartController : Controller
    {
        public IActionResult AddToCart()
        {
            return View();
        }
    }
}