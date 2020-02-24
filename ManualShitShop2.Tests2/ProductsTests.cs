using Autofac.Extras.Moq;
using ManualShitShop2.Models;
using ManualShitShop2.Services;
using System;
using Xunit;

namespace ManualShitShop2.Tests2
{
    public class ProductsTests
    {
        [Theory]
        [InlineData("AK-47", 2000, 20)]
        public void CreateProduct(string name, decimal price, int stock)
        {
            var product = new Product { Name = name, Price = price, Stock = stock };
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IProductService>().Setup(x => x.CreateProduct(product)).Returns(product);
            }
            
        }
        [Theory]
        [InlineData("AK-47", 2000, 20)]
        public void DeleteProduct(string name, decimal price, int stock)
        {
            var product = new Product { Name = name, Price = price, Stock = stock };
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IProductService>().Setup(x => x.CreateProduct(product));
                mock.Mock<IProductService>().Setup(x => x.DeleteProduct(product.ProductID)).Returns(product);
            }
        }
    }
}
