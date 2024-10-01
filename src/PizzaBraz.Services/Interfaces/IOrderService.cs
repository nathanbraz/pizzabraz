using PizzaBraz.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBraz.Services.Interfaces
{
    public interface IOrderService
    {
        Task<OrderDTO> Create(OrderDTO orderDTO);
        Task<OrderDTO> Update(OrderDTO orderDTO);
        Task Remove(Guid id);
        Task<OrderDTO> Get(Guid id);
    }
}
