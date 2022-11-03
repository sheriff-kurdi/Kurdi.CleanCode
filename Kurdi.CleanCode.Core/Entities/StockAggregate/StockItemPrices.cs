using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Kurdi.CleanCode.Core.Entities.StockAggregate
{
    [Owned]
    public class StockItemPrices
    {
        private double _sellingPrice;
        [Column(name: "selling_price")]
        public double SellingPrice
        {
            get
            {
                if (IsDiscounted) {return _sellingPrice - Discount;}
                else {return _sellingPrice;}
            }
            set => _sellingPrice = value;
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