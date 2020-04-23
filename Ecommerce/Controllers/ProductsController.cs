using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using Newtonsoft.Json;

namespace Ecommerce.Controllers
{
    public class ProductsController : Controller
    {
        public ProductsController()
        {
        }
        // GET: Products
        public ActionResult Index()
        {
            var products = ProductRepository.GetProducts();

            foreach (var item in products)
            {
                item.Category = CategoryRepository.GetCategoryById(item.CategoryId);
            }

            return View(products);
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            var product = ProductRepository.GetProductById(id);

            return View(product);
        }

        public IActionResult Buy(int id)
        {
            var cart = HttpContext.Session.Get<List<OrderDetail>>("cart");
            if(cart == null)
            {
                cart = new List<OrderDetail>();
                var orderDetaili = new OrderDetail()
                {
                    Product = ProductRepository.GetProductById(id),
                    Quantity = 1
                };
                cart.Add(orderDetaili);
                HttpContext.Session.Set<List<OrderDetail>>("cart", cart);
            }
            else
            {
                foreach(var item in cart)
                {
                    if(item.Product.Id == id)
                    {
                        item.Quantity++;
                    }
                }
                HttpContext.Session.Set<List<OrderDetail>>("cart", cart);
            }
            return RedirectToAction("Index");
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.Categories = CategoryRepository.GetCategories();
            
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            try
            {
                ProductRepository.Insert(product);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return RedirectToAction(nameof(Create));
            }
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            var product = ProductRepository.GetProductById(id);

            return View(product);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Product product)
        {
            try
            {
                ProductRepository.Update(product);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            var product = ProductRepository.GetProductById(id);

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var product = ProductRepository.GetProductById(id);

            try
            {
                ProductRepository.Remove(product);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }

    public static class SessionExtensions
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value, Formatting.None,
                        new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        }));
        }
        public static T Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) :
                                  JsonConvert.DeserializeObject<T>(value);
        }
    }
}