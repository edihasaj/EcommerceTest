using Ecommerce.Models;
using Ecommerce.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ecommerce.Controllers
{
    public class StockControlsController : Controller
    {
        // GET: StockControls
        public ActionResult Index()
        {
            var stockControls = StockControlRepository.GetStockControls();

            return View(stockControls);
        }

        // GET: StockControls/Details/5
        public ActionResult Details(int id)
        {
            var stockControl = StockControlRepository.GetStockControlById(id);

            return View(stockControl);
        }

        // GET: StockControls/Create
        public ActionResult Create()
        {
            var stocks = StockRepository.GetStocks();

            ViewBag.Products = new SelectList(ProductRepository.GetProducts(), "Id", "Name");

            ViewData["StockId"] = new SelectList(stocks, "Id", "StockName");
            return View();
        }

        // POST: StockControls/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StockControl stockControl)
        {
            try
            {
                StockControlRepository.Insert(stockControl);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                var stocks = StockRepository.GetStocks();
                ViewData["StockId"] = new SelectList(stocks, "Id", "StockName");
                return View();
            }
        }

        // GET: StockControls/Edit/5
        public ActionResult Edit(int id)
        {
            var stocks = StockRepository.GetStocks();
            ViewData["StockId"] = new SelectList(stocks, "Id", "StockName");
            return View();
        }

        // POST: StockControls/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, StockControl stockControl)
        {
            try
            {
                StockControlRepository.Update(stockControl);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                var stocks = StockRepository.GetStocks();
                ViewData["StockId"] = new SelectList(stocks, "Id", "StockName");
                return View();
            }
        }

        // GET: StockControls/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StockControls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var stockControl = StockControlRepository.GetStockControlById(id);

            try
            {
                StockControlRepository.Remove(stockControl);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}