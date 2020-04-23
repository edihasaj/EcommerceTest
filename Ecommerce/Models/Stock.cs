using System.Collections.Generic;

namespace Ecommerce.Models
{
    public class Stock
    {
        public int Id { get; set; }
        public string StockName { get; set; }
        public List<StockControl> StockControls { get; set; }
    }
}
