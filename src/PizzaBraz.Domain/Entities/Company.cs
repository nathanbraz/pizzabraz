using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBraz.Domain.Entities
{
    public class Company : Base
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string CNPJ { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Subdomain { get; set; }

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
