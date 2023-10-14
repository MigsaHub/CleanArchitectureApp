﻿ 
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
        public bool Temporary { get; set; } = false; 
        public string URL { get; set; } = string.Empty;
        public string Observation { get; set; } = string.Empty;
        public User User { get; set; } = new User();
    }
}