using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaBraz.API.ViewModels;
using PizzaBraz.API.ViewModels.Order;
using PizzaBraz.Domain.Enums;
using PizzaBraz.Services.DTO;
using PizzaBraz.Services.Interfaces;

namespace PizzaBraz.API.Controllers
{
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("/api/v1/orders/create")]
        public async Task<IActionResult> Create([FromBody] CreateOrderViewModel order)
        {
            try
            {
                var orderDTO = _mapper.Map<OrderDTO>(order);
                orderDTO.CreatedAt = DateTime.UtcNow;
                orderDTO.UpdatedAt = null;
                orderDTO.Status = OrderStatusEnum.Pendente.ToString();

                var orderCreated = await _orderService.Create(orderDTO);

                return Ok(new ResultViewModel { 
                    Message = "Pedido cadastrado com sucesso.",
                    Success = true,
                    Data = orderCreated
                });
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro ao cadastrar um pedido");
            }
        }
    }
}
