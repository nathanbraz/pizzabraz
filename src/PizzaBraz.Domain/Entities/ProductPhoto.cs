using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBraz.Domain.Entities
{
    public class ProductPhoto : Base
    {
        public Guid ProductId { get; private set; }
        public string PhotoPath { get; private set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public bool IsMain { get; private set; }
        public int DisplayOrder { get; private set; }

        public Product Product { get; set; }

        public override bool Validate()
        {
            return true;
        }
    }
}
