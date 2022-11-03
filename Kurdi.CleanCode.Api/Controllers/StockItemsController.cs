using Kurdi.CleanCode.Api.Requests;
using Kurdi.CleanCode.Infrastructure.DTOs;
using Kurdi.CleanCode.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kurdi.CleanCode.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StockItemsController : Controller
{
    private readonly StockItemService _stockItemService;

    public StockItemsController(StockItemService stockItemService)
    {
        _stockItemService = stockItemService;
    }
    
    // GET: api/<StockItemsController>
    [HttpGet]
    public List<StockItemsDto> Get([FromQuery] StockItemsRequestParameters requestParameters)
    {
        var stockItems = _stockItemService.FindAll()
            .Include(s => s.StockItemDetails)
            
            .Skip(requestParameters.PageNumber)
            .Take(requestParameters.PageSize)
            .Select(s => new StockItemsDto()
            {
                Sku = s.Sku,
                Name = s.StockItemDetails.FirstOrDefault(d => d.LanguageCode == "ar")!.Name,
                Description = s.StockItemDetails.FirstOrDefault(d => d.LanguageCode == "ar")!.Description,
                Category = s.CategoryName,
                StockItemPrices = s.StockItemPrices,
                StockItemQuantity = s.StockItemQuantity
            });
        
        if (requestParameters.Sku != null)
        {
            stockItems = stockItems.Where(s => s.Sku == requestParameters.Sku);
        }
        if (requestParameters.Category != null)
        {
            stockItems = stockItems.Where(s => s.Category == requestParameters.Category);
        }
        if (requestParameters.Name != null)
        {
            stockItems = stockItems.Where(s => s.Name == requestParameters.Name);
        }
        return stockItems.ToList();
    }
}