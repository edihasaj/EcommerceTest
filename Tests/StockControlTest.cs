using Ecommerce.Models;
using Ecommerce.Repository;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    [TestFixture]
    class StockControlTest
    {
        private StockControl stockControl;
        private List<StockControl> stockControlList;

        [SetUp]
        public void SetupStockControl()
        {
            stockControlList = new List<StockControl>();

            stockControl = new StockControl
            {
                Id = 10,
                ProductAmount = 5000,
                Product = new Product
                {
                    Name = "Mollë",
                    Description = "Frut",
                    PurchasePrice = .79,
                    RetailPrice = .79,
                },
                Stock = new Stock
                {
                    StockName = "Fruta"
                }
            };
        }

        [Test]
        public void GetInitialStockControlTest()
        {
            stockControlList = StockControlRepository.GetStockControls();

            if (stockControlList.Count() <= 0)
                Assert.IsEmpty(stockControlList);
            else
                Assert.IsNotEmpty(stockControlList);
        }

        [Test]
        public void GetStockControlByIdTest()
        {
            StockControlRepository.Insert(stockControl);

            var stockControlFromList = StockControlRepository.GetStockControlById(stockControl.Id);

            Assert.IsNotNull(stockControlFromList);
        }

        [Test]
        public void InsertStockControlTest()
        {
            StockControlRepository.Insert(stockControl);
            var stockControlFromList = StockControlRepository.GetStockControlById(stockControl.Id);

            Assert.AreEqual(stockControl, stockControlFromList);
        }

        [Test]
        public void UpdateStockControlTest()
        {
            StockControlRepository.Insert(stockControl);
            var stockControlFromList = StockControlRepository.GetStockControlById(stockControl.Id);

            stockControlFromList.ProductAmount = 6000;
            stockControlFromList.Product.Description = "Frut Test";
            stockControlFromList.Product.PurchasePrice = .99;

            StockControlRepository.Update(stockControlFromList);

            Assert.Contains(stockControlFromList, StockControlRepository.GetStockControls());
        }

        [Test]
        public void RemoveStockControlTest()
        {
            StockControlRepository.Insert(stockControl);
            var stockControlFromList = StockControlRepository.GetStockControlById(stockControl.Id);

            StockControlRepository.Remove(stockControlFromList);
            var checkRemovedStockControl = StockControlRepository.GetStockControlById(stockControlFromList.Id);

            Assert.IsNull(checkRemovedStockControl);
        }
    }
}
