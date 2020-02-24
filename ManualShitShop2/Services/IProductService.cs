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
        Task<List<Product>> GetProductsAsync(string name, int page, int size);
        Task<int> GetCountAsync();
        Product GetProduct(int id);
        Product CreateProduct(Product product);
        Product UpdateProduct(int id, Product product);
        Product DeleteProduct(int id);
    }
}
