using System.ComponentModel.DataAnnotations.Schema;

namespace Kurdi.CleanCode.Core.Entities.Stock.Details
{
    [Table(name:"stock_item_details")]
    public class StockItemDetails
    {
        public StockItemDetailsId StockItemDetailsId { get; set; }
        [Column(name:"name")]
        public string Name { get; set; }
        [Column(name:"description")]
        public string Description { get; set; }
    }
}