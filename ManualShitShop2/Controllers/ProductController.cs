using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManualShitShop2.Models;
using ManualShitShop2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManualShitShop2.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService ProductService;
        private readonly IOrderService OrderService;
        public ProductController(IProductService productService, IOrderService orderService)
        {
            this.ProductService = productService;
            this.OrderService = orderService;
        }
        // GET: Product
        public ActionResult Index()
        {
            var products = ProductService.GetProducts();
            return View(products);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            var product = ProductService.GetProduct(id);
            return View(product);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                var product = new Product { Name = collection["Name"], Price = Convert.ToDecimal(collection["Price"]) };
                ProductService.CreateProduct(product);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Buy(int id)
        {
            var claim = HttpContext.User;
            OrderService.Buy(id, claim);
            return View();
        }
    }
}