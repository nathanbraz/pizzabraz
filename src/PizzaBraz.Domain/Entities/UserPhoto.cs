using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBraz.Domain.Entities
{
    public class UserPhoto : Base
    {
        public Guid UserId { get; private set; }
        public string PhotoPath { get; private set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public bool IsMain { get; private set; }
        public int DisplayOrder { get; private set; }

        public User User { get; set; }

        public override bool Validate()
        {
            return true;
        }
    }
}
