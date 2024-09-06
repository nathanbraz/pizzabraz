using PizzaBraz.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBraz.Services.Interfaces
{
    public interface ICompanyService
    {
        Task<CompanyDTO> Create(CompanyDTO companyDTO);
        Task<CompanyDTO> Update(CompanyDTO companyDTO);
        Task Remove(Guid id);
        Task<CompanyDTO> Get(Guid id);
        Task<List<CompanyDTO>> GetAll();
        Task<CompanyDTO> GetByCNPJ(string cnpj);
    }
}
