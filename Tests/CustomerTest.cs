using Ecommerce.Repository;
using NUnit.Framework;
using System;
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

            Assert.AreEqual(2, customersList.Count());
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
        public void GetCustomerByName()
        {
            var result = CustomerRepository.
                GetCustomers()
                .Single(x=>x.FirstName == "Dren");

            Assert.AreEqual("Dren", result.FirstName);
        }

        [Test]
        public void InsertCustomerWithoutIdTest()
        {
            CustomerRepository.Insert(customerWithoutId);
            var customerFromList = CustomerRepository.GetCustomerById(customerWithoutId.Id);

            Assert.AreEqual(customer.FirstName, customerFromList.FirstName);
        }

        [Test]
        public void InsertCustomer()
        {
            CustomerRepository.Insert(customer);
            var customerFromList = CustomerRepository.GetCustomerById(customer.Id);

            Assert.AreEqual(customer, customerFromList);
        }

        [Test]
        public void UpdateCustomer()
        {
            CustomerRepository.Update(customerToUpdate);

            var updatedCustomer = CustomerRepository.GetCustomerById(customer.Id);
            Assert.AreEqual(customerToUpdate, updatedCustomer);
        }

        [Test]
        public void RemoveCustomer()
        {
            CustomerRepository.Insert(customer);
            var customerFromList = CustomerRepository.GetCustomerById(customer.Id);

            CustomerRepository.Remove(customerFromList);
            var checkRemovedCustomer = CustomerRepository.GetCustomerById(customerFromList.Id);
            
            Assert.IsNull(checkRemovedCustomer);
        }
    }
}