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
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        private readonly PizzaBrazContext _context;

        public CustomerRepository(PizzaBrazContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Customer>> GetByCompanyId(Guid companyId)
        {
            return await _context.Customers.Where(x => x.CompanyId == companyId).ToListAsync();
        }

        public async Task<Customer> GetByNumber(string number)
        {
            return await _context.Customers.SingleOrDefaultAsync(x => x.WhatsAppNumber == number);
        }

        public async Task<List<Customer>> SearchByName(string name)
        {
            var customers = await _context.Customers
                                 .Where(x => EF.Functions.Like(x.Name, $"%{name}%"))
                                 .AsNoTracking()
                                 .ToListAsync();
            return customers;
        }
    }
}
