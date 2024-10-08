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
    public class OrderItemService : IOrderItemService
    {
        public readonly IOrderItemRepository _orderItemRepository;
        public readonly IProductRepository _productRepository;
        public readonly IMapper _mapper;

        public OrderItemService(IOrderItemRepository orderItemRepository, IProductRepository productRepository, IMapper mapper)
        {
            _orderItemRepository = orderItemRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<OrderItemDTO> Create(OrderItemDTO orderItemDTO)
        {
            var orderItemExists = await _orderItemRepository.VerifyExistsOrderItem(orderItemDTO.OrderId, orderItemDTO.ProductId);
            if (orderItemExists)
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
