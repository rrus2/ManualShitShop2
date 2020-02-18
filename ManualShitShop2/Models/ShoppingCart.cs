using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManualShitShop2.Models
{
    public class ShoppingCart
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public string UserID { get; set; }
        public int Amount { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
