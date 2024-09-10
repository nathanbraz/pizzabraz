using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBraz.Domain.Entities
{
    public class Product : Base
    {
        public Guid ProductTypeId { get; private set; }
        public Guid CompanyId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }

        public ProductType ProductType { get; set; }
        public Company Company { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
        public ICollection<ProductPhoto> ProductPhotos { get; set; }

        public override bool Validate()
        {
            return true;
        }
    }
}
