using Kurdi.CleanCode.Api.Requests;
using Kurdi.CleanCode.Core.Entities.StockAggregate;
using Kurdi.CleanCode.Services;
using Microsoft.AspNetCore.Mvc;

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
    public List<StockItem> Get([FromQuery] StockItemsRequestParameters requestParameters)
    {
        var stockItems = _stockItemService.FindAll()
            .Where(s => s.CategoryName == requestParameters.Category)
            .Skip(requestParameters.PageNumber)
            .Take(requestParameters.PageSize)
            .ToList();
        return stockItems;
    }
}