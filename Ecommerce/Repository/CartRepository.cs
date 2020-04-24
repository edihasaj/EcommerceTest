using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ecommerce.Repository
{
    public static class CartRepository
    {
        private static List<Cart> _cartsList = new List<Cart>();

        public static void AddToCart(Cart cart)
        {
            if (_cartsList.Any())
            {
                    int lastId = _cartsList.Last().Id;
                    cart.Id = ++lastId;
                    cart.ItemId = 100 + lastId;
                    _cartsList.Add(cart);
            }
            else
            {
                cart.ItemId = 100 + 1;
                _cartsList.Add(cart);
            }
        }

        public static void Update(Cart cart)
        {
            var cartInList = GetCardItemById(cart.Id);

            cartInList.Id = cart.Id;
            cartInList.ItemId = cart.ItemId;
            cartInList.Quantity = cart.Quantity;
            cartInList.ProductId = cart.ProductId;
            cartInList.Product = cart.Product;
        }

        public static void RemoveCardItem(Cart cart)
        {
            _cartsList.Remove(cart);
        }

        public static List<Cart> GetCardItems()
        {
            return _cartsList;
        }

        public static Cart GetCardItemById(int id)
        {
            return _cartsList.FirstOrDefault(c => c.Id == id);
        }

        public static Cart GetCardItemByProductId(int productId)
        {
            return _cartsList.FirstOrDefault(c => c.ProductId == productId);
        }
    }

    public class EmptyCartListException : ApplicationException
    {
    }
}
