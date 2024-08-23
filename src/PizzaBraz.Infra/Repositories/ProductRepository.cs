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
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly PizzaBrazContext _context;

        public ProductRepository(PizzaBrazContext context) : base(context)
        {
            _context = context;
        }
    }
}
