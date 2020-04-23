using Ecommerce.Models;
using Ecommerce.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Ecommerce.Controllers
{
    public class StocksController : Controller
    {
        // GET: Stocks
        public ActionResult Index()
        {
            var stocks = StockRepository.GetStocks();
            var stockIds = stocks.Select(i => i.Id).ToList();
            var stockControls = StockControlRepository.GetStockControls();

            var categoryStocks = stockControls.Where(t => stockIds.Contains(t.StockId));

            foreach (var stock in stocks)
            {
                var stockControlId = StockControlRepository.GetStockControlById(stock.Id);

                if (stock.StockControls == null)
                {
                    stock.StockControls = new List<StockControl>();
                }

                if (stockControlId.StockId == stock.Id)
                {
                    stock.StockControls.AddRange(categoryStocks);
                }
            }

            return View(stocks);
        }

        // GET: Stocks/Details/5
        public ActionResult Details(int id)
        {
            var stock = StockRepository.GetStockById(id);

            return View(stock);
        }

        // GET: Stocks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Stocks/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Stock stock)
        {
            try
            {
                StockRepository.Insert(stock);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Stocks/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Stocks/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Stock stock)
        {
            try
            {
                StockRepository.Update(stock);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Stocks/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Stocks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var stock = StockRepository.GetStockById(id);

            try
            {
                StockRepository.Remove(stock);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}