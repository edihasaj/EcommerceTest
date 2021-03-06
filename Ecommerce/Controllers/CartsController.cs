﻿using Ecommerce.Models;
using Ecommerce.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ecommerce.Controllers
{
    public class CartsController : Controller
    {
        // GET: Carts
        public ActionResult Index()
        {
            return View(CartRepository.GetCartItems());
        }

        // POST: Carts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int productId)
        {
            try
            {
                var cartInList = CartRepository.GetCartItemByProductId(productId);

                if (cartInList != null)
                {
                    if(cartInList.StockControl.ProductAmount > cartInList.Quantity) 
                    {
                        cartInList.Quantity = ++cartInList.Quantity;
                        CartRepository.Update(cartInList);
                    }
                    else
                    {
                        var stockControls = Repository.StockControlRepository.GetStockControls();
                        ModelState.AddModelError(string.Empty, "Nuk ka produkt te mjaftueshem ne stok!");
                        return View("~/Views/StockControls/Index.cshtml", stockControls);
                    }
                }
                else
                {
                    var cartItem = new Cart
                    {
                        Quantity = 1,
                        CreatedAt = DateTimeOffset.Now,
                        StockControlId = productId,
                        StockControl = Repository.StockControlRepository.GetStockControlById(productId)
                    };

                    CartRepository.AddToCart(cartItem);
                }

                return RedirectToAction(nameof(Index), "StockControls");
            }
            catch
            {
                return View();
            }
        }

        // GET: Carts/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Carts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Carts/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Carts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var cartInList = CartRepository.GetCartItemById(id);

                if (cartInList == null)
                {
                    return NotFound();
                }

                if(cartInList.Quantity > 1)
                {
                    cartInList.Quantity = --cartInList.Quantity;
                    CartRepository.Update(cartInList);
                }
                else
                {
                    CartRepository.RemoveCartItem(cartInList);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult ProceedOrder()
        {  
            HttpContext.Session.Set<List<Cart>>("cartV",CartRepository.GetCartItems());
            return RedirectToAction("Create", "Orders");
        }

        // POST: Carts/IncreaseQuantity
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult IncreaseQuantity(int productId)
        {
            try
            {
                var cartInList = CartRepository.GetCartItemByProductId(productId);

                if (cartInList != null)
                {
                    if (cartInList.StockControl.ProductAmount > cartInList.Quantity)
                    {
                        cartInList.Quantity = ++cartInList.Quantity;
                        CartRepository.Update(cartInList);
                    }
                    else
                    {
                        var cartItems = CartRepository.GetCartItems();
                        ModelState.AddModelError(string.Empty, "Nuk ka produkt te mjaftueshem ne stok!");
                        return View("~/Views/Carts/Index.cshtml", cartItems);
                    }
                }
               
                return RedirectToAction(nameof(Index), "Carts");
            }
            catch
            {
                return View();
            }
        }
    }
}