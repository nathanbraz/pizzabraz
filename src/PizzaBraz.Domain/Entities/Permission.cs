using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBraz.Domain.Entities
{
    public class Permission : Base
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public ICollection<RolePermission> RolePermissions { get; set; }

       public override bool Validate()
        {
            return true;
        }
    }
}
