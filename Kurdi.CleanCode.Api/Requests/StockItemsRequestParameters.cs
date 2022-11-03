using System.ComponentModel.DataAnnotations;

namespace Kurdi.CleanCode.Api.Requests;

public class StockItemsRequestParameters : BaseRequestParameters
{
    private string? _category;

    public string? Category
    {
        get => _category;
        set => _category = value?.ToUpper();
    }

    private string? _sku;

    public string? Sku
    {
        get => _sku;
        set => _sku = value?.ToLower();
    }

    private string? _name;

    public string? Name
    {
        get => _name;
        set => _name = value?.ToLower();
    }
}