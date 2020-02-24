using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManualShitShop2.Models;
using ManualShitShop2.ViewModels;
using ReflectionIT.Mvc.Paging;

namespace ManualShitShop2.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _db;
        public ProductService(ApplicationDbContext db)
        {
            this._db = db;
        }
        public async Task<Product> CreateProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException("Product is null");
            }
            try
            {
                _db.Products.Add(product);
                await _db.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new Exception("Fail creating product");
            }
            return product;

        }

        public async Task<Product> DeleteProduct(int id)
        {
            if (id == 0)
            {
                throw new Exception("Deleting id 0 is not possible");
            }
            var item = _db.Products.Find(id);
            try
            {
                
                _db.Products.Remove(item);
                await _db.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new Exception("Fail deleting product");
            }
            return item;
        }

        public async Task<int> GetCountAsync()
        {
            var productCount = _db.Products.Count();
            return productCount;
        }

        public async Task<Product> GetProduct(int id)
        {
            var product = await _db.Products.FindAsync(id);
            return product;

        }

        public async Task<List<Product>> GetProductsAsync(string name, int page, int size = 5)
        {
            var products = _db.Products.AsEnumerable();
            if (name != null && name != string.Empty)
                products = products.Where(x => x.Name.ToUpper().Contains(name.ToUpper()));
            products = products.OrderBy(x => x.Name).Skip((page - 1) * size).Take(size);
            return products.ToList();

        }

        public async Task<Product> UpdateProduct(int id, Product product)
        {
            if (id == 0 || product == null)
            {
                throw new Exception("Fail data for update product");
            }
            var item = await _db.Products.FindAsync(id);
            item.Name = product.Name;
            item.Price = product.Price;
            _db.Products.Update(item);
            await _db.SaveChangesAsync();
            return product;
        }
    }
}
