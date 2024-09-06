using Microsoft.EntityFrameworkCore;
using PizzaBraz.Domain.Entities;
using PizzaBraz.Infra.Context;
using PizzaBraz.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBraz.Infra.Repositories
{
    public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {
        private readonly PizzaBrazContext _context;

        public CompanyRepository(PizzaBrazContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Company> GetByCNPJ(string cnpj)
        {
            return await _context.Companies.SingleOrDefaultAsync(x => x.CNPJ == cnpj);
        }
    }
}
