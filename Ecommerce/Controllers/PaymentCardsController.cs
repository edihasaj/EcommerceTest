using Ecommerce.Models;
using Ecommerce.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    public class PaymentCardsController : Controller
    {
        // GET: PaymentCards
        public ActionResult Index()
        {
            return View(PaymentCardRepository.GetPaymentCards());
        }

        // GET: PaymentCards/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PaymentCards/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PaymentCards/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PaymentCard paymentCard)
        {
            try
            {
                PaymentCardRepository.Insert(paymentCard);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PaymentCards/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PaymentCards/Edit/5
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

        // GET: PaymentCards/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PaymentCards/Delete/5
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
    }
}