
using System.Linq;
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
            int count = ProductRepository.GetProducts().Count;

            Assert.AreEqual(count, 2);
        }

        [Test]
        public void CountProducts_ShouldFail()
        {
            int count = ProductRepository.GetProducts().Count;

            Assert.AreEqual(count, 3);
        }

        [Test]
        public void InsertProduct()
        {
            ProductRepository.Insert(newProduct);
            var result = ProductRepository.GetProducts().Last();
            Assert.AreEqual(newProduct.Name, result.Name);
        }
    }
}
