using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBraz.Domain.Entities
{
    public class Company : Base
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string CNPJ { get; private set; }
        public string Address { get; private set; }
        public string Phone { get; private set; }
        public string Email { get; private set; }
        public string Subdomain { get; private set; }

        public ICollection<Product> Products { get; set; }
        public ICollection<Customer> Customers { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<Order> Orders { get; set; }

        public override bool Validate()
        {
            return true;
        }
    }
}
