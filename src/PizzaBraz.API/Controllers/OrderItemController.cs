﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaBraz.API.ViewModels;
using PizzaBraz.API.ViewModels.OrderItem;
using PizzaBraz.Infra.Interfaces;
using PizzaBraz.Services.DTO;
using PizzaBraz.Services.Interfaces;

namespace PizzaBraz.API.Controllers
{
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemService _orderItemService;
        private readonly IMapper _mapper;

        public OrderItemController(IOrderItemService orderItemService, IMapper mapper)
        {
            _orderItemService = orderItemService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("/api/v1/orderitems/create")]
        public async Task<IActionResult> Create([FromBody] CreateOrderItemViewModel orderItem)
        {
            try
            {
                var orderItemDTO = _mapper.Map<OrderItemDTO>(orderItem);
                orderItemDTO.CreatedAt = DateTime.UtcNow;
                orderItemDTO.UpdatedAt = null;

                var orderItemCreated = await _orderItemService.Create(orderItemDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Item inserido com sucesso.",
                    Success = true,
                    Data = orderItemCreated
                });
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro ao inserir um item no pedido.");
            }
        }
    }
}