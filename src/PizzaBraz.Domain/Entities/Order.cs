﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBraz.Domain.Entities
{
    public class Order : Base
    {
        public Guid CustomerId { get; private set; }
        public Guid CompanyId { get; private set; }
        public DateTime Date { get; private set; }
        public string Status { get; private set; }
        public decimal Total { get; private set; }

        public Customer Customer { get; set; }
        public Company Company { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }

        public override bool Validate()
        {
            return true;
        }
    }
}
