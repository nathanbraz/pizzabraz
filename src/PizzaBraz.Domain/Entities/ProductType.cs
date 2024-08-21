using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBraz.Domain.Entities
{
    public class ProductType : Base
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public override bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}
