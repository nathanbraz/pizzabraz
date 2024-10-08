using AutoMapper;
using PizzaBraz.Core.Exceptions;
using PizzaBraz.Domain.Entities;
using PizzaBraz.Infra.Interfaces;
using PizzaBraz.Infra.Repositories;
using PizzaBraz.Services.DTO;
using PizzaBraz.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBraz.Services.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<OrderDTO> Create(OrderDTO orderDTO)
        {
            var order = _mapper.Map<Order>(orderDTO);
            var orderCreated = await _orderRepository.Create(order);

            return _mapper.Map<OrderDTO>(order);
        }

        public async Task<OrderDTO> Get(Guid id)
        {
            var order = await _orderRepository.Get(id);

            return _mapper.Map<OrderDTO>(order);
        }

        public async Task Remove(Guid id)
        {
            await _orderRepository.Remove(id);
        }

        public async Task<OrderDTO> Update(OrderDTO orderDTO)
        {
            var orderExists = await _orderRepository.Get(orderDTO.Id);

            if(orderExists == null)
            {
                throw new DomainException("Não existe nenhum pedido com este Id.");
            }

            var order = _mapper.Map<Order>(orderDTO);
            var orderUpdated = await _orderRepository.Update(order);

            return _mapper.Map<OrderDTO>(orderUpdated);
        }

        public async Task<List<OrderDTO>> GetAll()
        {
            var orders = await _orderRepository.GetAll();

            return _mapper.Map<List<OrderDTO>>(orders);
        }

        public async Task<List<OrderDTO>> GetAllWithOrderItems()
        {
            var orderWithOrderItems = await _orderRepository.GetAllWithOrderItems();

            return _mapper.Map<List<OrderDTO>>(orderWithOrderItems);
        }
    }
}
