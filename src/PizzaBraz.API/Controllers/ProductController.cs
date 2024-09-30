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

                return Ok(new ResultViewModel
                {
                    Data = productCreated,
                    Success = true,
                    Message = "Produto cadastrado com sucesso."
                });
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro ao cadastrar um produto.");
            }
        }

        [HttpGet]
        [Route("/api/v1/products/{id}")]
        public async Task<IActionResult> GetProduct([FromRoute] Guid id)
        {
            try
            {
                var product = await _productService.Get(id);

                if(product == null)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "Não existe produto com o Id informado.",
                        Success = false,
                        Data = null
                    });
                }

                return Ok(new ResultViewModel
                {
                    Message = "Produto encontrado com sucesso.",
                    Success = true,
                    Data = product
                });
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro ao buscar um produto");
            }
        }

        [HttpGet]
        [Route("/api/v1/products")]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var products = await _productService.GetAll();

                return Ok(new ResultViewModel
                {
                    Message = "Produtos listados com sucesso.",
                    Success = true,
                    Data = products
                });
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro ao listar os produtos");
            }
        }
    }
}
