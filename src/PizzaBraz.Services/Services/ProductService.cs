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
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public ProductService(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<ProductDTO> Create(ProductDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);
            product.Validate();

            var productCreated = await _productRepository.Create(product);

            return _mapper.Map<ProductDTO>(productCreated);
        }

        public async Task<ProductDTO> Update(ProductDTO productDTO)
        {
            var productExists = await _productRepository.Get(productDTO.Id);

            if (productExists == null)
            {
                throw new DomainException("Não existe nenhum produto com o id informado");
            }

            var product = _mapper.Map<Product>(productDTO);
            product.Validate();

            var productUpdated = _productRepository.Update(product);

            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<ProductDTO> Get(Guid id)
        {
            var product = await _productRepository.Get(id);

            return _mapper.Map<ProductDTO>(product);
        }

        public async Task Remove(Guid id)
        {
            await _productRepository.Remove(id);
        }        
    }
}
