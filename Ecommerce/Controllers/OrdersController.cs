using System.Collections.Generic;
using Ecommerce.Models;
using Ecommerce.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Ecommerce.Controllers
{
    public class OrdersController : Controller
    {
        // GET: Orders
        public ActionResult Index()
        {
            var list = OrderRepository.GetOrders();

            foreach (var item in list)
            {
                item.Customer = CustomerRepository.GetCustomerById(item.CustomerId);
            }

            return View(list);
        }

        // GET: Orders/Details/5
        public ActionResult Details(int id)
        {
            return View(OrderRepository.GetOrderById(id));
        }

        // GET: Orders/Create
        [HttpGet]
        public ActionResult Create()
        {
            var model = new Order();

            //ViewBag.Customers = new SelectList(CustomerRepository.GetCustomers(), "Id", "FullName");
            model.Customers =  CustomerRepository.GetCustomers();
            model.CartDetails = HttpContext.Session.Get<List<Cart>>("cartV");

            //var productRepository = new ProductRepository();
            //model.Products = ProductRepository.GetProducts();

            //var a = HttpContext.Session.Get<List<OrderDetails>>("cart");
            //ViewBag.Products = new SelectList (a, "Id", "Name");

            return View(model);
        }

        // POST: Orders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Order model)
        {
            model.CartDetails = HttpContext.Session.Get<List<Cart>>("cartV");

            foreach (var detail in model.CartDetails)
            {
                model.TotalPrice += detail.Product.Product.RetailPrice * detail.Quantity;
            }

            OrderRepository.Insert(model);

            PaymentCardRepository.Insert(model.Payment);

            return RedirectToAction(nameof(Index));
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int id)
        {
            var orderDetails = OrderRepository.GetOrderById(id);

            return View(orderDetails);
        }

        // POST: Orders/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Order order)
        {
            try
            {
                OrderRepository.Update(order);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int id)
        {
            var orderDetails = OrderRepository.GetOrderById(id);

            return View(orderDetails);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var orderDetails = OrderRepository.GetOrderById(id);

            try
            {
                OrderRepository.Remove(orderDetails);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        
    }
}