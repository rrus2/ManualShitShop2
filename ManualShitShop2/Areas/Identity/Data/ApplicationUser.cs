using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ManualShitShop2.Models;
using Microsoft.AspNetCore.Identity;

namespace ManualShitShop2.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
