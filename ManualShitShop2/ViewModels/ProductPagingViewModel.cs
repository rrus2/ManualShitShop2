using ManualShitShop2.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManualShitShop2.ViewModels
{
    public class ProductPagingViewModel : PageModel
    {
        public int CurrentPage { get; set; } = 1;
        public int Count { get; set; }
        public int PageSize { get; set; } = 5;
        public int TotalPages => (int)Math.Ceiling(decimal.Divide(Count, PageSize));
        public List<Product> Products { get; set; }
    }
}
