using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBraz.Domain.Entities
{
    public class Product : Base
    {
        public Guid ProductTypeId { get; set; }
        public Guid CompanyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public ProductType ProductType { get; set; }
        public Company Company { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }

        public override bool Validate()
        {
            return true;
        }
    }
}
