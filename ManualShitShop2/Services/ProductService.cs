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
        public void CreateProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException("Product is null");
            }
            try
            {
                _db.Products.Add(product);
                _db.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Fail creating product");
            }


        }

        public void DeleteProduct(int id)
        {
            if (id == 0)
            {
                throw new Exception("Deleting id 0 is not possible");
            }

            try
            {
                var item = _db.Products.Find(id);
                _db.Products.Remove(item);
                _db.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Fail deleting product");
            }

        }

        public Product GetProduct(int id)
        {
            var product = _db.Products.FirstOrDefault(x => x.ProductID == id);
            return product;

        }

        public async Task<List<Product>> GetProductsAsync(int page, int size = 5)
        {
            var products = _db.Products.OrderBy(x => x.Name).Skip((page - 1) * size).Take(size);
            return products.ToList();

        }

        public void UpdateProduct(int id, Product product)
        {
            if (id == 0 || product == null)
            {
                throw new Exception("Fail data for update product");
            }
            var item = _db.Products.Find(id);
            item.Name = product.Name;
            item.Price = product.Price;
            _db.Products.Update(item);
            _db.SaveChanges();
        }
    }
}
