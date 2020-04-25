using Ecommerce.Models;
using Microsoft.EntityFrameworkCore.Internal;
using System.Collections.Generic;
using System.Linq;

namespace Ecommerce.Repository
{
    public static class StockRepository
    {
        private static List<Stock> _stocks = new List<Stock>()
    {
        new Stock()
        {
            Id = 1,
            StockName = "Higjiena",
        },
        new Stock()
        {
            Id = 2, 
            StockName = "Teknologji",
        }
    };

        public static void Insert(Stock stock)
        { 
            int lastId = _stocks.Last().Id;
            stock.Id = ++lastId;
            _stocks.Add(stock);
        }

        public static void Update(Stock stock)
        {
            var stockItem = _stocks.FirstOrDefault(s => s.Id == stock.Id);

            stockItem.StockName = stock.StockName;
        }

        public static void Remove(Stock product)
        {
            _stocks.Remove(product);
        }

        public static List<Stock> GetStocks()
        {
            return _stocks;
        }

        public static Stock GetStockById(int id)
        {
            return _stocks.FirstOrDefault(s => s.Id == id);
        }

        public static Stock GetStockByProductId(int productId)
        {
            return _stocks.FirstOrDefault(s => s.StockControls.All(p => p.Product.Id == productId));
        }
    }
}
