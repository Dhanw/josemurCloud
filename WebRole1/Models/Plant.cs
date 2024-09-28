using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebRole1.Models
{
    public class Plant
    {
        public int PlantId { get; set; }
        public string PlantName { get; set; }
        public string Species { get; set; }
        public decimal Price { get; set; }
        public int InStock { get; set; }
    }
}