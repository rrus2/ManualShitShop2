using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ManualShitShop2.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(1, double.MaxValue)]
        public decimal Price { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int Stock { get; set; }
        [Range(1, int.MaxValue)]
        public int Amount { get; set; }
        public string ImagePath { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
