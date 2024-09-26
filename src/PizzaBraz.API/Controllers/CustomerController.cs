using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaBraz.API.ViewModels;
using PizzaBraz.API.ViewModels.Customer;
using PizzaBraz.Domain.Entities;
using PizzaBraz.Services.DTO;
using PizzaBraz.Services.Interfaces;

namespace PizzaBraz.API.Controllers
{
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerService customerService, ITokenService tokenService, IMapper mapper)
        {
            _customerService = customerService;
            _tokenService = tokenService;
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
                return StatusCode(500, "Ocorreu um erro ao cadastrar um cliente.");
            }                                                                                                                                  
        }

        [HttpPost]
        [Route("/api/v1/customers/generate-token")]
        public async Task<IActionResult> GenerateToken([FromBody] string whatsappNumber)
        {
            try
            {
                var customer = await _customerService.GetByNumber(whatsappNumber);
                if (customer == null)
                {
                    var customerDTO = new CustomerDTO
                    {
                        Name = "CLIENTE",
                        WhatsAppNumber = whatsappNumber,
                        CreatedAt = DateTime.UtcNow,
                        UpdateAt = null,
                        CompanyId = Guid.Parse("ae9e4d39-ef70-43a6-9246-74c0c41a5f27")
                    };

                    customer = await _customerService.Create(customerDTO);
                }

                //Gerando Token
                var token = _tokenService.GenerateCustomerToken(customer.Id);

                return Ok(new ResultViewModel
                {
                    Data = new { token, customer },
                    Success = true,
                    Message = "Token gerado com sucesso."
                });
            }
            catch (Exception)
            {
                return StatusCode(500, "Falha na geração de token do cliente.");
            }
        }

        [HttpGet]
        [Route("/api/v1/customers/validate-token")]
        public IActionResult ValidateToken([FromQuery] string token)
        {
            if (!_tokenService.ValidateCustomerToken(token))
            {
                return Unauthorized(new ResultViewModel
                {
                    Data = token,
                    Success = true,
                    Message = "Token inválido ou expirado."
                });
            }

            return Ok(new ResultViewModel
            {
                Data = token,
                Success = true,
                Message = "Token válido"
            });

        }

        [HttpGet]
        [Route("api/v1/customers/teste")]
        public IActionResult Teste()
        {
            return Ok(new { Name = "Nathan", LastName = "Braz", Age = 25 });
        }
    }
}
