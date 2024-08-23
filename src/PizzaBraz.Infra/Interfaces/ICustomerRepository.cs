using PizzaBraz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBraz.Infra.Interfaces
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
    }
}
