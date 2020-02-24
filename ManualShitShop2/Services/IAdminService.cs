using ManualShitShop2.Areas.Identity.Data;
using ManualShitShop2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManualShitShop2.Services
{
    public interface IAdminService
    {
        Task CreateUser(CreateUserViewModel model);
        Task<List<ApplicationUser>> GetUsers();
        Task<CreateUserViewModel> GetUser(string id);
    }
}
