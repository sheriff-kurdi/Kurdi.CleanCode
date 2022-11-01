using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kurdi.CleanCode.Core.Entities.CategoryAggregate;

[Table(name:"categories")]
public class Category
{
    [Key]
    [Column(name:"name")]
    public string Name { get; set; }
    [Column(name:"is_parent")]
    public bool IsParent { get; set; }
    
    [Column(name:"parent")]
    public string ParentName { get; set; }
    [ForeignKey(name:"parent")]
    public Category Parent { get; set; }
    
    
}