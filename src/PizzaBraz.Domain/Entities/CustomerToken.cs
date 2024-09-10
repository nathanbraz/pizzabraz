using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBraz.Domain.Entities
{
    public class CustomerToken : Base
    {
        public Guid CustomerId { get; private set; }
        public Guid Token { get; private set; }
        public DateTime TokenCreatedAt { get; private set; }
        public DateTime TokenExpiresAt { get; private set; }
        public bool IsUsed { get; private set; }

        public Customer Customer { get; set; }

        public override bool Validate()
        {
            return true;
        }
    }
}
