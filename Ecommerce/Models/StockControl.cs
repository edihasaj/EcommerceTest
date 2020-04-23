namespace Ecommerce.Models
{
    public class StockControl
    {
        public int Id { get; set; }
        public int ProductAmount { get; set; }
        public Product Product { get; set; }

        public int StockId { get; set; }
        public Stock Stock { get; set; }
    }
}
