using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Kurdi.CleanCode.Core.Entities.StockAggregate
{
    [Owned]
    public class StockItemPrices
    {
        [Column(name: "selling_price")]
        public double SellingPrice
        {
            // ReSharper disable once FunctionRecursiveOnAllPaths
            get
            {
                if (IsDiscounted) {return SellingPrice - Discount;}
                else {return SellingPrice;}
            }
            set
            {
                if (value <= 0) throw new ArgumentOutOfRangeException(nameof(value));
                SellingPrice = value;
            }
        }

        [Column(name:"cost_price")]
        public double CostPrice { get; set; }
        [Column(name:"discount")]
        // ReSharper disable once MemberCanBePrivate.Global
        public double Discount { get; set; }
        [Column(name:"is_discounted")]
        // ReSharper disable once MemberCanBePrivate.Global
        public bool IsDiscounted { get; set; }
    }
}