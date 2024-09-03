using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBraz.Domain.Entities
{
    public class Customer : Base
    {
        public string Name { get; set; }
        public string WhatsAppNumber { get; set; }
        public string Email { get; set; }

        public Guid CompanyId { get; set; }
        public Company Company { get; set; }

        public ICollection<CustomerAddress> CustomerAddresses { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<CustomerToken> CustomerTokens { get; set; }

        public override bool Validate()
        {
            return true;
        }
    }
}
