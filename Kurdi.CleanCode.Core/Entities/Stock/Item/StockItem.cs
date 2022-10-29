using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Kurdi.CleanCode.Core.Entities.Stock.Details;

namespace Kurdi.CleanCode.Core.Entities.Stock.Item
{
    [Table(name:"stock_item")]
    public class StockItem
    {
        [Key]
        public string Sku { get; set; }
        [Column(name:"supplier_identity")]
        public int SupplierIdentity { get; set; }
        public StockItemPrices StockItemPrices { get; set; }
        public StockItemQuantity StockItemQuantity { get; set; }
        public List<StockItemDetails> StockItemDetails { get; set; }
        
        
    }
}
