using Ecommerce.Models;
using System.Collections.Generic;
using System.Linq;

namespace Ecommerce.Repository
{
    public static class StockControlRepository
    {
        private static List<StockControl> _stockControls = new List<StockControl>()
    {
        new StockControl()
        {
            Id = 1,
            ProductAmount = 1,
            Product = ProductRepository.GetProductById(1),
            StockId = 2,
            Stock = StockRepository.GetStockById(2)
        },
        new StockControl()
        {
            Id = 2,
            ProductAmount = 3,
            Product = ProductRepository.GetProductById(2),
            StockId = 2,
            Stock = StockRepository.GetStockById(2)
        }
    };

        public static void Insert(StockControl stockControl)
        {
            int lastId = _stockControls.Last().Id;
            stockControl.Id = ++lastId;
            _stockControls.Add(stockControl);
        }

        public static void Update(StockControl stockControl)
        {
            var stockControlItem = _stockControls.FirstOrDefault(s => s.Id == stockControl.Id);

            stockControlItem.ProductAmount = stockControl.ProductAmount;
            stockControlItem.StockId = stockControl.StockId;
            stockControlItem.Product.Name = stockControl.Product.Name;
            stockControlItem.Product.Description = stockControl.Product.Description;
            stockControlItem.Product.PurchasePrice = stockControl.Product.PurchasePrice;
            stockControlItem.Product.RetailPrice = stockControl.Product.RetailPrice;
        }

        public static void Remove(StockControl stockControl)
        {
            _stockControls.Remove(stockControl);
        }

        public static List<StockControl> GetStockControls()
        {
            return _stockControls;
        }

        public static StockControl GetStockControlById(int id)
        {
            return _stockControls.FirstOrDefault(x => x.Id == id);
        }
    }
}
