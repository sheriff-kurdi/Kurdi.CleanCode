using Kurdi.CleanCode.Core.Entities.StockAggregate;

namespace Kurdi.CleanCode.Infrastructure.DTOs;

public class StockItemsDto
{
    public string Sku { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public StockItemPrices StockItemPrices { get; set; }
    public StockItemQuantity StockItemQuantity { get; set; }
}