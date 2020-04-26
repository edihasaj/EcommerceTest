
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

            Assert.AreEqual(count, 2);
        }

        [Test]
        public void CountProducts_ShouldFail()
        {
            int count = ProductLogic.CountProducts();

            //Assert.AreEqual(count, 3);
        }

        [Test]
        public void InsertProduct()
        {
            ProductLogic.Insert(newProduct);
            var result = ProductLogic.GetProducts().Last();
            Assert.AreEqual(newProduct.Name, result.Name);
        }

        [Test]
        public void UpdateProduct()
        {
            
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
