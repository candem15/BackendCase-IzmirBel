using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product : BaseEntity
    {
        public decimal Price { get; set; }
        public float Quantity { get; set; }
        public string Unit { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
