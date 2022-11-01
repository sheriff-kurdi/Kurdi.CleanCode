using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kurdi.CleanCode.Core.Entities
{
    [Table(name:"languages")]
    public class Language 
    {
        [Key]
        [Column(name:"language_code")]
        public string LanguageCode { get; set; }
        [Column(name:"language_name")]
        public string LanguageName { get; set; }
    }
}