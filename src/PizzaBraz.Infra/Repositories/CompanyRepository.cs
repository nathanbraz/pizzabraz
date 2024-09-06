using Microsoft.EntityFrameworkCore;
using PizzaBraz.Domain.Entities;
using PizzaBraz.Infra.Context;
using PizzaBraz.Infra.Interfaces;

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
            var company1 = await _context.Companies.ToListAsync();

            var company = await _context.Companies.Where(x => x.CNPJ == cnpj).FirstOrDefaultAsync();

            //var company = await _context.Companies.SingleOrDefaultAsync(x => x.CNPJ == cnpj);

            return company;
        }
    }
}
