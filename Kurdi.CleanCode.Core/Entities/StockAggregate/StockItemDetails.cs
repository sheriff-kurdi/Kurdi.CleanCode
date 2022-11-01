using System.ComponentModel.DataAnnotations.Schema;

namespace Kurdi.CleanCode.Core.Entities.StockAggregate
{
    [Table(name:"stock_items_details")]
    public class StockItemDetails
    {
        [Column(name:"language_code")]
        public string LanguageCode { get; set; }
        [ForeignKey(name:"LanguageCode")]
        public Language Language { get; set; }
        
        [Column(name:"sku")]
        public string Sku { get; set; }
        [ForeignKey(name:"Sku")]
        public StockItem StockItem { get; set; }
        
        [Column(name:"name")]
        public string Name { get; set; }
        
        [Column(name:"description")]
        public string Description { get; set; }
    }
}