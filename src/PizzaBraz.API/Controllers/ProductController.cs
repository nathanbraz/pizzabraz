using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaBraz.API.ViewModels;
using PizzaBraz.API.ViewModels.Product;
using PizzaBraz.Services.DTO;
using PizzaBraz.Services.Interfaces;

namespace PizzaBraz.API.Controllers
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("/api/v1/products/create")]
        public async Task<IActionResult> Create([FromBody] CreateProductViewModel product)
        {
            try
            {
                var productDTO = _mapper.Map<ProductDTO>(product);
                productDTO.CreatedAt = DateTime.UtcNow;
                productDTO.UpdatedAt = null;

                var productCreated = await _productService.Create(productDTO);

                var productViewModel = _mapper.Map<ProductViewModel>(productDTO);

                return Ok(new ResultViewModel
                {
                    Data = productViewModel,
                    Success = true,
                    Message = "Produto cadastrado com sucesso."
                });
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro ao cadastrar um produto");
            }
        }
    }
}
