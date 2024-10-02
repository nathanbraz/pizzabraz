using PizzaBraz.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBraz.Services.Interfaces
{
    public interface IOrderItemService
    {
        Task<OrderItemDTO> Create(OrderItemDTO orderItemDTO);
        Task<OrderItemDTO> Update(OrderItemDTO orderItemDTO);
        Task<OrderItemDTO> Get(Guid id);
        Task Remove(Guid id);
    }
}
