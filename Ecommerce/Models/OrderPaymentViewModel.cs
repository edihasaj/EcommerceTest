using System.Collections.Generic;
using Ecommerce.Models;

public class OrderPaymentViewModel
{
    public List<OrderDetail> OrderDetails { get; set; }
    public PaymentCard PaymentCard { get; set; }
    public int CustomerId { get; set; }
    public virtual Customer Customer { get; set; }
}