using PizzaBraz.Domain.Entities;
using PizzaBraz.Infra.Context;
using PizzaBraz.Infra.Interfaces;

namespace PizzaBraz.Infra.Repositories
{
    public class ProductTypeRepository : BaseRepository<ProductType>, IProductTypeRepository
    {
        private readonly PizzaBrazContext _context;

        public ProductTypeRepository(PizzaBrazContext context) : base(context)
        {
            _context = context;
        }
    }
}
