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
    }
}
