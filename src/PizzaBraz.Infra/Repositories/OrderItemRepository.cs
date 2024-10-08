﻿using Microsoft.EntityFrameworkCore;
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
    public class OrderItemRepository : BaseRepository<OrderItem>, IOrderItemRepository
    {
        private readonly PizzaBrazContext _context;

        public OrderItemRepository(PizzaBrazContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> VerifyExistsOrderItem(Guid orderId, Guid productId)
        {
            return await _context.OrderItems.AnyAsync(x => x.OrderId == orderId && x.ProductId == productId);
        }
    }
}
