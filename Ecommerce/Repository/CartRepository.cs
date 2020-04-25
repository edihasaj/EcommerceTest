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
            var cartInList = GetCartItemById(cart.Id);

            cartInList.Id = cart.Id;
            cartInList.ItemId = cart.ItemId;
            cartInList.Quantity = cart.Quantity;
            cartInList.StockControlId = cart.StockControlId;
            cartInList.StockControl = cart.StockControl;
        }

        public static void RemoveCartItem(Cart cart)
        {
            _cartsList.Remove(cart);
        }

        public static List<Cart> GetCartItems()
        {
            return _cartsList;
        }

        public static Cart GetCartItemById(int id)
        {
            return _cartsList.FirstOrDefault(c => c.Id == id);
        }

        public static Cart GetCartItemByProductId(int productId)
        {
            return _cartsList.FirstOrDefault(c => c.StockControl.Product.Id == productId);
        }

        public static bool IncreaseQuantity(int productId)
        {
            var cartInList = GetCartItemByProductId(productId);

            if (cartInList != null)
            {
                if (cartInList.StockControl.ProductAmount > cartInList.Quantity)
                {
                    cartInList.Quantity = ++cartInList.Quantity;
                    Update(cartInList);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
    }

    public class EmptyCartListException : ApplicationException
    {
    }
}
