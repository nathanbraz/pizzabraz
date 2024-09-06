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
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CompanyService(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<CompanyDTO> Create(CompanyDTO companyDTO)
        {
            var companyExists = await _companyRepository.GetByCNPJ(companyDTO.CNPJ);

            if (companyExists != null)
            {
                throw new DomainException("Já existe uma empresa cadastrada neste CNPJ.");
            }

            var company = _mapper.Map<Company>(companyDTO);
            company.Validate();

            var companyCreated = await _companyRepository.Create(company);
            return _mapper.Map<CompanyDTO>(companyCreated);
        }

        public async Task<CompanyDTO> Update(CompanyDTO companyDTO)
        {
            var companyExists = await _companyRepository.Get(companyDTO.Id);

            if (companyExists == null)
            {
                throw new DomainException("Não existe nenhuma empresa com o id informado.");
            }

            var company = _mapper.Map<Company>(companyDTO);
            company.Validate();

            var companyUpdated = await _companyRepository.Update(company);

            return _mapper.Map<CompanyDTO>(companyUpdated);

        }

        public async Task<CompanyDTO> Get(Guid id)
        {
            var company = await _companyRepository.Get(id);

            return _mapper.Map<CompanyDTO>(company);
        }

        public async Task<List<CompanyDTO>> GetAll()
        {
            var companies = await _companyRepository.GetAll();

            return _mapper.Map<List<CompanyDTO>>(companies);
        }

        public async Task Remove(Guid id)
        {
            await _companyRepository.Remove(id);
        }

        public async Task<CompanyDTO> GetByCNPJ(string cnpj)
        {
            var company = await _companyRepository.GetByCNPJ(cnpj);

            return _mapper.Map<CompanyDTO>(company);
        }
    }
}
