using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Domain
{
    public class Property
    {
        public int Id { get; set; }
        public string Status { get; set; } = string.Empty;
        public string Area { get; set; } = string.Empty;
        public decimal Price { get; set; } 
        public bool Temporary { get; set; } = false; 
        public string URL { get; set; } = string.Empty;
        public string Observation { get; set; } = string.Empty;
        public User User { get; set; } = new User();
    }
}
