using ManualShitShop2.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManualShitShop2.Models
{
    public class Order
    {
        public string ApplicationUserID { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int? ProductID { get; set; }
        public Product Product { get; set; }
    }
}
