using Ecommerce.Models;
using Ecommerce.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    [TestFixture]
    class OrderTest
    {
        private Order order;
        private List<Order> orderList;

        [SetUp]
        public void SetupOrder()
        {
            orderList = new List<Order>();

            order = new Order
            {
                Id = 10,
                Customers = new List<Customer>()
                {
                    CustomerRepository.GetCustomerById(1),
                    CustomerRepository.GetCustomerById(2),
                },
                Products = ProductRepository.GetProducts(),
                Date = DateTime.Now,
                DeliveryAddress = "Prishtine",
                TotalPrice = 2999,
                OrderDetails = new List<OrderDetail>(),
                CartDetails = new List<Cart>(),
                Payment = new PaymentCard
                {
                    CardNumber = "4466446644665588",
                    CardName = "Besa Gashi",
                    CVV = "211",
                    ExpirationDate = new DateTime(2022, 04, 24)
                }
            };
        }

        [Test]
        public void GetInitialOrdersTest()
        {
            orderList = OrderRepository.GetOrders();

            Assert.AreEqual(0, orderList.Count);
        }

        [Test]
        public void GetOrderById()
        {
            OrderRepository.Insert(order);

            var orderFromList = OrderRepository.GetOrderById(order.Id);

            Assert.IsNotNull(orderFromList);
        }

        [Test]
        public void InsertOrderTest()
        {
            OrderRepository.Insert(order);
            var orderFromList = OrderRepository.GetOrderById(order.Id);

            Assert.AreEqual(order, orderFromList);
        }

        [Test]
        public void UpdateOrder()
        {
            OrderRepository.Insert(order);
            var orderFromList = OrderRepository.GetOrderById(order.Id);

            orderFromList.DeliveryAddress = "Prishtine2";
            orderFromList.Payment.CardNumber = "435444611665068";
            orderFromList.Payment.CardName = "MS. Besa GASHI";
            orderFromList.Payment.CVV = "444";
            orderFromList.Payment.ExpirationDate = new DateTime(2023, 06, 24);

            OrderRepository.Update(orderFromList);

            Assert.Contains(orderFromList, OrderRepository.GetOrders());
        }

        [Test]
        public void RemoveOrderTest()
        {
            OrderRepository.Insert(order);
            var orderFromList = OrderRepository.GetOrderById(order.Id);

            OrderRepository.Remove(orderFromList);
            var checkRemovedOrder = OrderRepository.GetOrderById(orderFromList.Id);

            Assert.IsNull(checkRemovedOrder);
        }
    }
}
