

using System;
using System.Collections.Generic;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

public class Order
{
    public List<Customer> Customers { get; set; }
    public List<Product> Products { get; set; }

    public int Id { get; set; }
    public DateTime Date { get; set; }

    [Display(Name = "Delivery Address")]
    public string DeliveryAddress { get; set; }


    public int CustomerId { get; set; }
    [Display(Name = "Customer")]
    public virtual Customer Customer { get; set; }

    

    [Display(Name = "Total Price")]
    public double TotalPrice { get; set; }

    // order details
    public Product Product { get; set; }
    public int Quantity { get; set; }
    public bool IsChecked { get; set; }

    public List<OrderDetail> OrderDetails { get; set; }
    public List<Cart> CartDetails { get; set; }

    public PaymentCard Payment { get; set; }
}

