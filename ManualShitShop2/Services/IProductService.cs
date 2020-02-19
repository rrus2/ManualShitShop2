﻿using ManualShitShop2.Models;
using ReflectionIT.Mvc.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManualShitShop2.Services
{
    public interface IProductService
    {
        Task<PagingList<Product>> GetProductsAsync();
        Product GetProduct(int id);
        void CreateProduct(Product product);
        void UpdateProduct(int id, Product product);
        void DeleteProduct(int id);
    }
}
