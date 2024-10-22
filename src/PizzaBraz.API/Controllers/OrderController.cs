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

        [HttpGet]
        [Route("/api/v1/orders")]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _orderService.GetAllWithOrderItems();

            return Ok(orders);
        }

        [HttpPost]
        [Route("/api/v1/orders/place-order")]
        public async Task<IActionResult> PlaceOrder([FromBody] CreateOrderViewModel order)
        {
            try
            {
                var orderDTO = _mapper.Map<OrderDTO>(order);
                orderDTO.CreatedAt = DateTime.UtcNow;
                orderDTO.UpdatedAt = null;
                orderDTO.Status = OrderStatusEnum.Pendente;

                var orderCreated = await _orderService.Create(orderDTO);

                return Ok(new ResultViewModel
                { 
                    Message = "Pedido realizado com sucesso.",
                    Success = true,
                    Data = orderCreated
                });
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro ao cadastrar um pedido");
            }
        }

        [HttpGet]
        [Route("/api/v1/orders/confirm-order/{id}")]
        public async Task<IActionResult> ConfirmOrder(Guid id)
        {
            try
            {
                var orderDTO = await _orderService.Get(id);
                if (orderDTO == null || orderDTO.Status != OrderStatusEnum.Pendente)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "Pedido inexistente ou não está pendente.",
                        Success = false,
                        Data = null
                    });
                }
                orderDTO.Status = OrderStatusEnum.Confirmado;
                orderDTO.UpdatedAt = DateTime.UtcNow;

                var orderUpdated = await _orderService.ConfirmOrder(id);

                return Ok(new ResultViewModel
                {
                    Message = "Pedido confirmado com sucesso",
                    Success = true,
                    Data = orderUpdated
                });

            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro ao confirmar o pedido.");
            }
        }
    }
}
