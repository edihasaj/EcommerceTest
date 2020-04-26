
using System.Linq;
using Ecommerce.Logic;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class ProductTest
    {
        Product p;
        Product pEmpty;
        Product newProduct;
        Product pUpdate;

        [SetUp]
        public void SetUp()
        {
            p = new Product()
            {
                Id = 1,
                Name = "Macbook Air",
                Description = "Diqka",
                PurchasePrice = 899,
                RetailPrice = 999,
                CategoryId = 1
            };

            pUpdate = new Product()
            {
                Id = 1,
                Name = "Macbook Air UPDATE",
                Description = "Diqka UPDATE",
                PurchasePrice = 899,
                RetailPrice = 999,
                CategoryId = 1
            };

            pEmpty = new Product();

            newProduct = new Product()
            {
                Name = "X1 Carbon",
                Description = "Diqka",
                PurchasePrice = 1500,
                RetailPrice = 1850,
                CategoryId = 1
            };
        }

        [Test]
        public void CountProducts()
        {
            int count = ProductLogic.CountProducts();

            Assert.AreEqual(2, count);
        }

        [Test]
        public void CountProducts_Empty()
        {
            int count = ProductLogic.CountProducts();

            Assert.AreNotEqual(-1, count);
        }

        [Test]
        public void CountProducts_ShouldFail()
        {
            int count = ProductLogic.CountProducts();

            Assert.AreEqual(count, 3);
        }

        [Test]
        public void InsertProduct()
        {
            ProductLogic.Insert(newProduct);
            var result = ProductLogic.GetProducts().Last();
            Assert.AreEqual(newProduct.Name, result.Name);
        }

        [Test]
        public void InsertProduct_Empty()
        {
            ProductLogic.Insert(pEmpty);
            var result = ProductLogic.GetProducts().Last();
            Assert.AreNotEqual(pEmpty, result);
        }

        [Test]
        public void UpdateProduct()
        {
            //var beforeUpdate = ProductRepository.GetProductById(p.Id);
            ProductLogic.Update(pUpdate);
            var afterUpdate = ProductLogic.GetProductById(p.Id);

            Assert.AreEqual(pUpdate, afterUpdate);
        }

        [Test]
        public void UpdateProduct_Exists()
        {
            //var beforeUpdate = ProductRepository.GetProductById(p.Id);
            ProductLogic.Update(p);
            var afterUpdate = ProductLogic.GetProductById(p.Id);

            Assert.AreEqual(p.Name, afterUpdate.Name);
        }

        [Test]
        public void ProductExists_ShouldFail()
        {
            var result = ProductLogic.Exists(newProduct);

            Assert.IsTrue(result);
        }

        [Test]
        public void ProductExists()
        {
            var result = ProductLogic.Exists(p);

            Assert.IsTrue(result);
        }
    }
}
