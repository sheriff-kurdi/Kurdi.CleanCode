using Kurdi.CleanCode.Api.Requests;
using Kurdi.CleanCode.Core.Entities.StockAggregate;
using Microsoft.AspNetCore.Mvc;

namespace Kurdi.CleanCode.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StockItemsController : Controller
{
    
    // GET: api/<StockItemsController>
    [HttpGet]
    public List<StockItem> Get([FromQuery] StockItemsRequestParameters requestParameters)
    {
        var employeesDto = new List<StockItem>();
        return employeesDto;
    }
}