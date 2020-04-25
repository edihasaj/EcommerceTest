using Ecommerce.Models;
using Ecommerce.Repository;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    [TestFixture]
    class StockTest
    {
        private Stock stock;
        private List<Stock> stockList;

        [SetUp]
        public void SetupStock()
        {
            stockList = new List<Stock>();

            stock = new Stock
            {
                Id = 20,
                StockName = "Makineri",
                StockControls = new List<StockControl>()
                {
                    new StockControl
                    {
                        ProductAmount = 10,
                        Product = new Product
                        {
                            Id = 10000,
                            Name = "Elektromotor",
                            PurchasePrice = 520,
                            RetailPrice = 520
                        }
                    }
                }
            };
        }

        [Test]
        public void GetInitialStockTest()
        {
            stockList = StockRepository.GetStocks();

            if (stockList.Count() <= 0)
                Assert.IsEmpty(stockList);
            else
                Assert.IsNotEmpty(stockList);
        }

        [Test]
        public void GetStockByIdTest()
        {
            StockRepository.Insert(stock);

            var stockFromList = StockRepository.GetStockById(stock.Id);

            Assert.IsNotNull(stockFromList);
        }

        [Test]
        public void InsertStockTest()
        {
            StockRepository.Insert(stock);
            var stockFromList = StockRepository.GetStockById(stock.Id);

            Assert.AreEqual(stock, stockFromList);
        }

        [Test]
        public void UpdateStockTest()
        {
            StockRepository.Insert(stock);
            var stockFromList = StockRepository.GetStockById(stock.Id);

            stockFromList.StockName = "Makineri Pjese Plotesuese";
            var stockProduct = stockFromList.StockControls.First();
            stockProduct.ProductAmount = 20;
            stockProduct.Product.Name = "Elektromotor per xyz";

            StockRepository.Update(stockFromList);

            var updatedStock = StockRepository.GetStockById(stock.Id);

            Assert.AreEqual(stock.StockControls.First().Product.Name, updatedStock.StockControls.First().Product.Name);
        }

        [Test]
        public void RemoveStockTest()
        {
            StockRepository.Insert(stock);
            var stockFromList = StockRepository.GetStockById(stock.Id);

            StockRepository.Remove(stockFromList);
            var checkRemovedStock = StockRepository.GetStockById(stockFromList.Id);

            Assert.IsNull(checkRemovedStock);
        }
    }
}
