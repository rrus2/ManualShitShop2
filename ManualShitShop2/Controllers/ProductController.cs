using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManualShitShop2.Models;
using ManualShitShop2.Services;
using ManualShitShop2.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        public ActionResult Index(int page = 1, int size = 5)
        {
            var products = ProductService.GetProductsAsync(page, size);
            var model = new ProductPagingViewModel { Products = products.GetAwaiter().GetResult(), CurrentPage = page, PageSize = size };
            return View(model);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            var product = ProductService.GetProduct(id);
            var listofstock = new List<int>();
            for (int i = 1; i < product.Stock; i++)
            {
                listofstock.Add(i);
            }
            var list = new SelectList(listofstock);
            ViewBag.Stock = list;
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
                var product = new Product { Name = collection["Name"], Price = Convert.ToDecimal(collection["Price"]), Stock = Convert.ToInt32(collection["Stock"]) };
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
        public async Task<ActionResult> Buy(int id, IFormCollection collection)
        {
            var product = ProductService.GetProduct(id);
            var claim = HttpContext.User;
            int amount = Convert.ToInt32(collection["Amount"]);
            await OrderService.Buy(id, claim, amount);
            return View("ThankYou");
        }
        public async Task<ActionResult> ThankYou()
        {
            return View();
        }
    }
}