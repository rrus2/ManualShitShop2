using ManualShitShop2.Models;
using ReflectionIT.Mvc.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManualShitShop2.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetProductsAsync(int page, int size);
        Task<int> GetCountAsync();
        Product GetProduct(int id);
        void CreateProduct(Product product);
        void UpdateProduct(int id, Product product);
        void DeleteProduct(int id);
    }
}
