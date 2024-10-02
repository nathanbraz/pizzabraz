using AutoMapper;
using PizzaBraz.Core.Exceptions;
using PizzaBraz.Domain.Entities;
using PizzaBraz.Infra.Interfaces;
using PizzaBraz.Services.DTO;
using PizzaBraz.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBraz.Services.Services
{
    public class OrderItemSercice : IOrderItemService
    {
        public readonly IOrderItemRepository _orderItemRepository;
        public readonly IMapper _mapper;

        public OrderItemSercice(IOrderItemRepository orderItemRepository, IMapper mapper)
        {
            _orderItemRepository = orderItemRepository;
            _mapper = mapper;
        }

        public async Task<OrderItemDTO> Create(OrderItemDTO orderItemDTO)
        {
            var orderItemExists = await _orderItemRepository.Get(orderItemDTO.Id);
            if (orderItemExists != null)
            {
                throw new DomainException("Esse item já está incluso no pedido.");
            }
            var orderItem = _mapper.Map<OrderItem>(orderItemDTO);

            var orderItemCreated = await _orderItemRepository.Create(orderItem);

            return _mapper.Map<OrderItemDTO>(orderItemCreated);
        }

        public async Task<OrderItemDTO> Get(Guid id)
        {
            var orderItem = await _orderItemRepository.Get(id);

            return _mapper.Map<OrderItemDTO>(orderItem);
        }

        public async Task Remove(Guid id)
        {
            await _orderItemRepository.Remove(id);
        }

        public async Task<OrderItemDTO> Update(OrderItemDTO orderItemDTO)
        {
            var orderItemExists = await _orderItemRepository.Get(orderItemDTO.Id);

            if(orderItemExists == null)
            {
                throw new DomainException("Não existe nenhum item com esse Id");
            }

            var orderItem = _mapper.Map<OrderItem>(orderItemDTO);
            var orderItemUpdated = await _orderItemRepository.Update(orderItem);

            return _mapper.Map<OrderItemDTO>(orderItemUpdated);
        }
    }
}
