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

        public ICollection<CustomerAddress> Addresses { get; set; }
        public ICollection<Order> Orders { get; set; }

        public override bool Validate()
        {
            throw new NotImplementedException();
        }

        //public string Name { get; set; }
        //public string WhatsAppNumber { get; set; }
        //public Guid Token { get; set; }
        //public DateTime TokenGeneratedDate { get; set; }

        //public ICollection<Address> Addresses { get; set; }
        //public ICollection<Order> Orders { get; set; }

        //public void SetToken(Guid token)
        //{
        //    Token = token;
        //    TokenGeneratedDate = DateTime.UtcNow;
        //}
    }
}
