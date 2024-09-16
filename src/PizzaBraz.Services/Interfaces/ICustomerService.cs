using PizzaBraz.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBraz.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<CustomerDTO> Create(CustomerDTO customerDTO);
        Task<CustomerDTO> Update(CustomerDTO customerDTO);
        Task Remove(Guid id);
        Task<CustomerDTO> Get(Guid id);
        Task<CustomerDTO> GetByNumber(string number);
        Task<List<CustomerDTO>> SearchByName(string name);

    }
}
