using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBraz.Domain.Entities
{
    public class CustomerToken : Base
    {
        public Guid CustomerId { get; set; }
        public Guid Token { get; set; }
        public DateTime TokenGeneratedDate { get; set; }
        public DateTime ExpiresAt { get; set; }
        public bool IsUsed { get; set; }

        public Customer Customer { get; set; }
    }
}
