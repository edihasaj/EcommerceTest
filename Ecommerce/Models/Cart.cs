using System;

namespace Ecommerce.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public int ProductId { get; set; }
        public StockControl Product { get; set; }
    }
}