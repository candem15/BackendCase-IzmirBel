using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Product
{
    public class CreateProductDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public float Quantity { get; set; }
        public string Unit { get; set; }
        public Guid? CategoryId { get; set; }
    }
}
