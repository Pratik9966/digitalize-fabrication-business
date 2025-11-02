
using DigitalizeFabricationBussiness.Utilities.Enumes;
using System.Collections.Generic;

namespace DigitalizeFabricationBussiness.DTOs
{
    public class ProductInputDTO
    {
        public string ProductName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public CategoryEnum Category { get; set; }
        public List<string> ProductImages { get; set; } = new List<string>();
    }

    public class ProductOutputDTO
    {
        public string ProductId { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public CategoryEnum Category { get; set; }
        public List<string> ProductImages { get; set; } = new List<string>();
    }
}
