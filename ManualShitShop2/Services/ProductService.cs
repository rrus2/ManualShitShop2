﻿using System;
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
        public Product CreateProduct(Product product)
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
            return product;

        }

        public Product DeleteProduct(int id)
        {
            if (id == 0)
            {
                throw new Exception("Deleting id 0 is not possible");
            }
            var item = _db.Products.Find(id);
            try
            {
                
                _db.Products.Remove(item);
                _db.SaveChanges();
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

        public Product GetProduct(int id)
        {
            var product = _db.Products.FirstOrDefault(x => x.ProductID == id);
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

        public Product UpdateProduct(int id, Product product)
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
            return product;
        }
    }
}
