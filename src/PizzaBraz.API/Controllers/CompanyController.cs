﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PizzaBraz.API.Utilities;
using PizzaBraz.API.ViewModels;
using PizzaBraz.API.ViewModels.Company;
using PizzaBraz.Core.Exceptions;
using PizzaBraz.Services.DTO;
using PizzaBraz.Services.Interfaces;

namespace PizzaBraz.API.Controllers
{
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpPost]
        [Route("/api/v1/companies/create")]
        public async Task<IActionResult> Create(CompanyViewModel companyViewModel)
        {
            try
            {
                var companyDTO = new CompanyDTO
                {
                    Name = companyViewModel.Name,
                    Description = companyViewModel.Description,
                    CNPJ = companyViewModel.CNPJ,
                    Address = companyViewModel.Address,
                    Phone = companyViewModel.Phone,
                    Email = companyViewModel.Email,
                    Subdomain = companyViewModel.Subdomain,
                    CreatedAt = DateTime.UtcNow,
                    UpdateAt = null
                };

                var companyCreated = await _companyService.Create(companyDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Empresa cadastrada com sucesso.",
                    Success = true,
                    Data = companyCreated
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro ao cadastrar um usuário.");
            }
        }
    }
}
