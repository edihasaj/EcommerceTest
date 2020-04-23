using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class CustomerTest
    {
        Customer customer;

        [SetUp]
        public void SetupCustomer()
        {
            customer = new Customer
            {
                Id = 100,
                FirstName = "Edi"
            };
        }

        // This will fail
        [Test]
        public void FailInsertCustomerTest()
        {
            CustomerRepository.Insert(customer);
            var customerFromList = CustomerRepository.GetCustomerById(100);

            Assert.AreEqual(customer.FirstName, customerFromList.FirstName);
        }

        // This will pass
        [Test]
        public void InsertCustomerTest()
        {
            CustomerRepository.Insert(customer);
            var customerFromList = CustomerRepository.GetCustomerById(2);

            Assert.AreEqual(customer.FirstName, customerFromList.FirstName);
        }
    }
}