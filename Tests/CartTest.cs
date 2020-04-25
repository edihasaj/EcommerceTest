using Ecommerce.Models;
using Ecommerce.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    [TestFixture]
    class CartTest
    {
        private Cart cart;
        private Cart cart2;
        private List<Cart> cartList;

        [SetUp]
        public void SetupCart()
        {
            cartList = new List<Cart>();

            cart = new Cart
            {
                Id = 10,
                ItemId = 115,
                Quantity = 1,
                CreatedAt = DateTime.Now,
                StockControl = new StockControl
                {
                    Id = 1,
                    ProductAmount = 5000,
                    Product = new Product
                    {
                        Id = 45,
                        Name = "Mollë",
                        Description = "Frut",
                        PurchasePrice = .79,
                        RetailPrice = .79,
                    },
                    Stock = new Stock
                    {
                        StockName = "Fruta"
                    }
                }
            };

            cart2 = new Cart
            {
                Id = 11,
                ItemId = 116,
                Quantity = 1,
                CreatedAt = DateTime.Now,
                StockControl = new StockControl
                {
                    Id = 2,
                    ProductAmount = 1,
                    Product = new Product
                    {
                        Id = 46,
                        Name = "Dardhë",
                        Description = "Frut",
                        PurchasePrice = .79,
                        RetailPrice = .79,
                    },
                    Stock = new Stock
                    {
                        StockName = "Fruta"
                    }
                }
            };
        }

        [Test]
        public void GetInitialCartItemsTest()
        {
            cartList = CartRepository.GetCartItems();

            if (cartList.Count() <= 0)
                Assert.IsEmpty(cartList);
            else
                Assert.IsNotEmpty(cartList);
        }

        [Test]
        public void GetCartItemByIdTest()
        {
            CartRepository.AddToCart(cart);

            var cartFromList = CartRepository.GetCartItemById(cart.Id);

            Assert.IsNotNull(cartFromList);
        }

        [Test]
        public void GetCartItemByProductIdTest()
        {
            CartRepository.AddToCart(cart);

            var cartItemFromList = CartRepository.GetCartItemByProductId(cart.StockControl.Product.Id);

            Assert.IsNotNull(cartItemFromList);
        }

        [Test]
        public void InsertCartItemTest()
        {
            CartRepository.AddToCart(cart);
            var cartFromList = CartRepository.GetCartItemById(cart.Id);

            Assert.AreEqual(cart, cartFromList);
        }

        [Test]
        public void UpdateCartItemTest()
        {
            CartRepository.AddToCart(cart);
            var cartFromList = CartRepository.GetCartItemByProductId(cart.StockControl.Product.Id);

            cartFromList.Quantity = 2;

            CartRepository.Update(cartFromList);

            Assert.Contains(cartFromList, CartRepository.GetCartItems());
        }

        [Test]
        public void RemoveCartItemTest()
        {
            CartRepository.AddToCart(cart);
            var cartItemFromList = CartRepository.GetCartItemById(cart.Id);

            CartRepository.RemoveCartItem(cartItemFromList);
            var checkRemovedCartItem = CartRepository.GetCartItemById(cartItemFromList.Id);

            Assert.IsNull(checkRemovedCartItem);
        }

        [Test]
        public void IncreaseQuantityTest()
        {
            CartRepository.AddToCart(cart);

            var increasedQuantity = CartRepository.IncreaseQuantity(cart.StockControl.Product.Id);

            Assert.IsTrue(increasedQuantity);
        }

        [Test]
        public void InsufficientAmountIncreaseQuantityTest()
        {
            CartRepository.AddToCart(cart2);

            var increasedQuantity = CartRepository.IncreaseQuantity(cart2.StockControl.Product.Id);

            Assert.IsFalse(increasedQuantity);
        }
    }
}
