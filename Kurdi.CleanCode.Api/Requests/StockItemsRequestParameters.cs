using System.ComponentModel.DataAnnotations;

namespace Kurdi.CleanCode.Api.Requests;

public class StockItemsRequestParameters : BaseRequestParameters
{
    private string? _category;
    [Required] public string? Category
    {
        get => _category;
        set => _category = value?.ToUpper();
    } 

}