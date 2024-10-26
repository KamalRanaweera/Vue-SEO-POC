using System.ComponentModel.DataAnnotations;

namespace POC.VueSEO.Api.Models
{
    public class PageData
    {
        [Key]
        public string Key { get; set; } = string.Empty;
      
        public string? Head { get; set; }
        
        public string? Body { get; set; }
    }
}
