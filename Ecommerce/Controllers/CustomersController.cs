using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            var customersList = CustomerRepository.GetCustomers();

            return View(customersList);
        }

        // GET: Customers/Details/5
        public ActionResult Details(int id)
        {
            var customerDetails = CustomerRepository.GetCustomerById(id);

            return View(customerDetails);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {

            try
            {
                CustomerRepository.Insert(customer);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int id)
        {
            var customerDetails = CustomerRepository.GetCustomerById(id);

            return View(customerDetails);
        }

        // POST: Customers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Customer customer)
        {
            var customerDetails = CustomerRepository.GetCustomerById(id);

            try
            {
                CustomerRepository.Update(customer);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int id)
        {
            var customerDetails = CustomerRepository.GetCustomerById(id);

            return View(customerDetails);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var customerDetails = CustomerRepository.GetCustomerById(id);

            try
            {
                CustomerRepository.Remove(customerDetails);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}