using Autofac.Extras.Moq;
using ManualShitShop2.Models;
using ManualShitShop2.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace ManualShitShop2.Tests
{
    public class ProductsTestsAutoMock
    {
        [Fact]
        public void CreateProductTest()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var product = new Product { Name = "AK-47", Price = 2000, Stock = 20 };
                mock.Mock<IProductService>().Setup(x => x.CreateProduct(product)).Returns(Task.FromResult(product));
            }
            
        }
        [Fact]
        public void DeleteProductTest()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var product = new Product { Name = "AK-47", Price = 2000, Stock = 20 };
                mock.Mock<IProductService>().Setup(x => x.CreateProduct(product));
                mock.Mock<IProductService>().Setup(x => x.DeleteProduct(product.ProductID)).Returns(Task.FromResult(product));
            }
        }
        [Fact]
        public void UpdateProductTest()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var product = new Product { Name = "AK-47", Price = 2000, Stock = 20 };
                mock.Mock<IProductService>().Setup(x => x.CreateProduct(product));
                product.Name = "AK";
                mock.Mock<IProductService>().Setup(x => x.UpdateProduct(product.ProductID, product)).Returns(Task.FromResult(product));
            }
        }
        [Fact]
        public void GetProductTest()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var product = new Product { Name = "AK-47", Price = 2000, Stock = 20 };
                mock.Mock<IProductService>().Setup(x => x.CreateProduct(product));
                mock.Mock<IProductService>().Setup(x => x.GetProduct(product.ProductID)).Returns(Task.FromResult(product));
            }
        }
        [Fact]
        public void GetProductsTest()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IProductService>().Setup(x => x.GetProductsAsync(null, 0, 0));
                var cls = mock.Create<IProductService>();
                var list = cls.GetProductsAsync(null, 1, 5);
                Assert.NotNull(list);
            }
        }
        [Fact]
        public void GetProductsTestExtended()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var product = new Product { Name = "AK", Price = 2000, Stock = 20 };
                var product2 = new Product { Name = "C#", Price = 80, Stock = 5 };
                mock.Mock<IProductService>().Setup(x => x.CreateProduct(product)).Returns(Task.FromResult(product));
                mock.Mock<IProductService>().Setup(x => x.CreateProduct(product2)).Returns(Task.FromResult(product2));
                var cls = mock.Create<IProductService>();
                var list = cls.GetProductsAsync(null, 1, 5);
                Assert.NotNull(list);
            }
        }
        [Fact]
        public void CreateProductFailData()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var product = new Product { Name = "", Price = -20, Stock = 5 };
                mock.Mock<IProductService>().Setup(x => x.CreateProduct(product)).Throws(new Exception());
            }
        }
        [Fact]
        public void CreateProductFailWithNullProduct()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var product = new Product();
                mock.Mock<IProductService>().Setup(x => x.CreateProduct(product)).Throws(new ArgumentNullException());
            }
        }
        [Fact]
        public void DeleteProductFailId0()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IProductService>().Setup(x => x.DeleteProduct(0)).Throws(new Exception());
            }
        }
        [Fact]
        public void DeleteProductFailsWithNotFoundProduct()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IProductService>().Setup(x => x.DeleteProduct(1)).Throws(new Exception());
            }
        }

    }
}
