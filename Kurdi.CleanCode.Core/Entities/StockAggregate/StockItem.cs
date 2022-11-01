using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Kurdi.CleanCode.Core.Entities.CategoryAggregate;

namespace Kurdi.CleanCode.Core.Entities.StockAggregate
{
    [Table(name:"stock_items")]
    public class StockItem
    {
        [Key]
        [Column(name:"sku")]
        public string Sku { get; set; }
        [Column(name:"supplier_identity")]
        public int SupplierIdentity { get; set; }
        public StockItemPrices StockItemPrices { get; set; }
        public StockItemQuantity StockItemQuantity { get; set; }
        public List<StockItemDetails> StockItemDetails { get; set; }
        
        [Column(name:"category")]
        public string CategoryName { get; set; }
        [ForeignKey(name:"CategoryName")]
        public Category Category { get; set; }
        
        
    }
}
