using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaBraz.API.ViewModels;
using PizzaBraz.API.ViewModels.Customer;
using PizzaBraz.Services.DTO;
using PizzaBraz.Services.Interfaces;

namespace PizzaBraz.API.Controllers
{
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("/api/v1/customers/create")]
        public async Task<IActionResult> Create([FromBody] CreateCustomerViewModel customer)
        {
            try
            {
                var customerDTO = _mapper.Map<CustomerDTO>(customer);
                customerDTO.CreatedAt = DateTime.UtcNow;
                customerDTO.UpdateAt = null;

                var customerCreated = await _customerService.Create(customerDTO);

                var customerViewModel = _mapper.Map<CustomerViewModel>(customerCreated);

                return Ok(new ResultViewModel
                {
                    Data = customerViewModel,
                    Message = "Cliente cadastrado com sucesso.",
                    Success = true
                });
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro ao cadastrar um usuário.");
            }                                                                                                                                  
        }
    }
}
