using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Kurdi.CleanCode.Core.Entities.Stock.Item;
using Microsoft.EntityFrameworkCore;

namespace Kurdi.CleanCode.Core.Entities.Stock.Details
{
    [Owned]
    public class StockItemDetailsId
    {
        [Key]
        [Column(name:"language_code")]
        public string LanguageCode { get; set; }
        [Key]
        [Column(name:"SKU")]
        public StockItem SKU { get; set; }
    }
}