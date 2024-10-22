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
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        private readonly PizzaBrazContext _context;

        public OrderRepository(PizzaBrazContext context) : base(context)
        {
            _context = context;
        }

        //public async Task<List<Order>> GetAll()
        //{
        //    var orders = await _context.Orders.ToListAsync();
        //    return orders;
        //}

        public async Task<List<Order>> GetAllWithOrderItems()
        {
            return await _context.Orders.AsNoTracking()
                                        .Include(x => x.OrderItems)
                                        .ThenInclude(oi => oi.Product)
                                        .ToListAsync();
        }


        public async Task<Order> GetWithOrderItems(Guid id)
        {
            return await _context.Orders
                                    .AsNoTracking()
                                    .Include(o => o.OrderItems)
                                    .ThenInclude(oi => oi.Product)
                                    .SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
