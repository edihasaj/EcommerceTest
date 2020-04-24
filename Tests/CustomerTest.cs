using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    [TestFixture]
    public class CustomerTest
    {
        private Customer customerWithoutId;
        private Customer customer;
        private Customer customerToUpdate;
        private List<Customer> customersList;

        [SetUp]
        public void SetupCustomer()
        {
            customersList = new List<Customer>();
            
            customerWithoutId = new Customer
            {
                FirstName = "Filan"
            };

            customer = new Customer
            {
                Id = 100,
                FirstName = "Filan"
            };

            customerToUpdate = new Customer()
            {
                Id = 100,
                FirstName = "Filan test",
                LastName = "Fisteku test",
                Address = "Prishtine test",
                Email = "filan22@fisteku.com"
            };
        }

        [Test]
        public void GetInitialCustomersTest()
        {
            customersList = CustomerRepository.GetCustomers();

            Assert.AreEqual(customersList.Count(), 2);
        }

        [Test]
        public void GetCustomerByIdTest()
        {
            var customer = CustomerRepository.GetCustomerById(1);

            Assert.IsNotNull(customer);
        }

        [Test]
        public void GetCustomerByEmailTest()
        {
            var customer = CustomerRepository.GetCustomerByEmail("edi@hasaj.com");

            Assert.IsNotNull(customer);
        }

        [Test]
        public void InsertCustomerWithoutIdTest()
        {
            CustomerRepository.Insert(customerWithoutId);
            var customerFromList = CustomerRepository.GetCustomerById(customerWithoutId.Id);

            Assert.AreEqual(customer.FirstName, customerFromList.FirstName);
        }

        [Test]
        public void InsertCustomerTest()
        {
            CustomerRepository.Insert(customer);
            var customerFromList = CustomerRepository.GetCustomerById(customer.Id);

            Assert.AreEqual(customer.FirstName, customerFromList.FirstName);
        }

        [Test]
        public void UpdateCustomerTest()
        {
            CustomerRepository.Insert(customer);
            var customerFromList = CustomerRepository.GetCustomerById(customer.Id);
            
            customerFromList.FirstName = customerToUpdate.FirstName;
            customerFromList.LastName = customerToUpdate.LastName;
            customerFromList.Address = customerToUpdate.Address;
            customerFromList.Email = customerToUpdate.Email;
            CustomerRepository.Update(customerFromList);

            var updatedCustomer = CustomerRepository.GetCustomerById(customer.Id);
            Assert.AreEqual(customerFromList, updatedCustomer);
        }

        [Test]
        public void RemoveCustomerTest()
        {
            CustomerRepository.Insert(customer);
            var customerFromList = CustomerRepository.GetCustomerById(customer.Id);

            CustomerRepository.Remove(customerFromList);
            var checkRemovedCustomer = CustomerRepository.GetCustomerById(customerFromList.Id);
            
            Assert.IsNull(checkRemovedCustomer);
        }
    }
}