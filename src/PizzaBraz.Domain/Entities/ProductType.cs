using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBraz.Domain.Entities
{
    public class ProductType : Base
    {
        public string Name { get; private set; }
        public string Type { get; private set; }
        public string Description { get; private set; }

        public override bool Validate()
        {
            return true;
        }
    }
}
