using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBraz.Domain.Entities
{
    public class Order : Base
    {
        public Guid CustomerId { get; set; }
        public Guid AddressId { get; set; }
        public Guid CompanyId { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public decimal Total { get; set; }

        public Customer Customer { get; set; }
        public Address Address { get; set; }
        public Company Company { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }

        public override bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}
