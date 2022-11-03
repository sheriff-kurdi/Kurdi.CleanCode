using System.ComponentModel.DataAnnotations;

namespace Kurdi.CleanCode.Api.Requests;

public class BaseRequestParameters
{
    [Required]
    [Range(0, Int32.MaxValue, ErrorMessage = "The PageNumber must be greater than or equal {0}.")]
    public int PageNumber { get; set; }
    [Required]
    [Range(1, Int32.MaxValue, ErrorMessage = "The PageNumber must be greater than or equal {1}.")]
    public int PageSize { get; set; }
}