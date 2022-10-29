using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kurdi.CleanCode.Core.Entities.Stock.Item
{
    public class StockItem
    {
        [Key]
        public string Sku { get; set; }
        [Column(name:"supplier_identity")]
        public int SupplierIdentity { get; set; }
        public StockItemPrices StockItemPrices { get; set; }
        public StockItemQuantity StockItemQuantity { get; set; }
        
        
    }
}
