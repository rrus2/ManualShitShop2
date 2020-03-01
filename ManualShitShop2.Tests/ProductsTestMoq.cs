using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ManualShitShop2.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace ManualShitShop2.Tests
{
    public class ProductsTestMoq
    {
        private readonly ApplicationDbContext _context;
        public ProductsTestMoq()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            _context = new ApplicationDbContext(options);
            _context.Database.EnsureCreated();
        }

        [Theory]
        [InlineData("AK-47", 2000, 20)]
        [InlineData("AK", double.MaxValue, int.MaxValue)]
        public void CreateProductSuccess(string name, decimal price, int stock)
        {
            //act
            var product = new Product { Name = name, Price = price, Stock = stock };
            _context.Products.Add(product);
            _context.SaveChanges();

            //arrange
            var list = _context.Products.ToList();

            //assert
            Assert.NotNull(list);
        }

        private void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}
