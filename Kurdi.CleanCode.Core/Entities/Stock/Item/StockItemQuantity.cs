using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Kurdi.CleanCode.Core.Entities.Stock.Item
{
    [Owned]
    public class StockItemQuantity
    {
        [Column(name:"total_stock")]
        public int TotalStock { get; private set; }
        [Column(name:"available_stock")]
        public int AvailableStock { get; private set; }
        [Column(name:"reserved_stock")]
        public int ReservedStock { get; private set; }
        

        public void AddStock(int quantity)
        {
            this.TotalStock += quantity;
            this.AvailableStock += quantity;
        }
        
        public void ReserveStock(int quantity)
        {
            this.ReservedStock += quantity;
            this.AvailableStock -= quantity;
        }

        public void CancelReservation(int quantity)
        {
            this.ReservedStock -= quantity;
            this.AvailableStock += quantity;
        }
    }
}
