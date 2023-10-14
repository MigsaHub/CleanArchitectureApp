 
using System.ComponentModel.DataAnnotations; 

namespace CleanArchitectureApp.Domain
{
    public class Property
    {
        [Key]
        public int Id { get; set; }
        public string Status { get; set; } = string.Empty;
        public string Area { get; set; } = string.Empty;
        public decimal Price { get; set; } 
        public int Temporary { get; set; }
        public string URL { get; set; } = string.Empty;
        public string Observation { get; set; } = string.Empty;
        public int User { get; set; }
    }
}
