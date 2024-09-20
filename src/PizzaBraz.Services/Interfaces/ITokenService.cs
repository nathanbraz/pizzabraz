using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBraz.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateCustomerToken(Guid customerId);
        bool ValidateCustomerToken(string token);
    }
}
