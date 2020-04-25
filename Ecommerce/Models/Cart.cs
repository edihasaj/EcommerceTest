using System;

namespace Ecommerce.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public int StockControlId { get; set; }
        public StockControl StockControl { get; set; }
    }
}