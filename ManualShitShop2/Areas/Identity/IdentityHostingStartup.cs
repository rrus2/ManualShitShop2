using System;
using ManualShitShop2.Areas.Identity.Data;
using ManualShitShop2.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(ManualShitShop2.Areas.Identity.IdentityHostingStartup))]
namespace ManualShitShop2.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            //builder.ConfigureServices((context, services) => {
            //    services.AddDbContext<ApplicationDbContext>(options =>
            //        options.UseSqlServer(
            //            context.Configuration.GetConnectionString("ApplicationDbContextConnection")));

            //    services.AddDefaultIdentity<ApplicationUser>()
            //        .AddEntityFrameworkStores<ApplicationDbContext>();
            //});
        }
    }
}