using AutoMapper;
using PizzaBraz.Core.Exceptions;
using PizzaBraz.Core.Services;
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
    public class CustomerService : ICustomerService
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(IMapper mapper, ICustomerRepository customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public async Task<CustomerDTO> Create(CustomerDTO customerDTO)
        {
            var customerExists = await _customerRepository.GetByNumber(customerDTO.WhatsAppNumber);

            if (customerExists != null)
            {
                throw new DomainException("Já existe um cliente cadastrado neste WhatsApp.");
            }

            var user = _mapper.Map<Customer>(customerDTO);
            user.Validate();

            var customerUpdated = await _customerRepository.Create(user);

            return _mapper.Map<CustomerDTO>(customerUpdated);
        }

        public async Task<CustomerDTO> Update(CustomerDTO customerDTO)
        {
            var customerExists = await _customerRepository.Get(customerDTO.Id);

            if (customerExists == null)
            {
                throw new DomainException("Não existe nenhum cliente com o id informado");
            }

            var customer = _mapper.Map<Customer>(customerDTO);
            customer.Validate();

            var customerUpdated = await _customerRepository.Update(customer);

            return _mapper.Map<CustomerDTO>(customerUpdated);
        }

        public async Task<CustomerDTO> Get(Guid id)
        {
            var customer = await _customerRepository.Get(id);

            return _mapper.Map<CustomerDTO>(customer);
        }

        public async Task<CustomerDTO> GetByNumber(string number)
        {
            var customer = await _customerRepository.GetByNumber(number);

            return _mapper.Map<CustomerDTO>(customer);
        }

        public async Task Remove(Guid id)
        {
            await _customerRepository.Remove(id);
        }

        public async Task<List<CustomerDTO>> SearchByName(string name)
        {
            var customer = await _customerRepository.SearchByName(name);

            return _mapper.Map<List<CustomerDTO>>(customer);
        }
    }
}
