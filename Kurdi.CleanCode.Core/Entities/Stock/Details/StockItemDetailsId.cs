using System.ComponentModel.DataAnnotations;
using Kurdi.CleanCode.Core.Entities.Stock.Item;

namespace Kurdi.CleanCode.Core.Entities.Stock.Details
{
    public class StockItemDetailsId
    {
        [Key]
        public Language Language { get; set; }
        [Key]
        public StockItem StockItem { get; set; }
    }
}