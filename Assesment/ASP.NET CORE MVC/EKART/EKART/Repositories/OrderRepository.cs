using EKART.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EKART.Repositories
{
    public class OrderRepository : IRepository<Order>
    {
        private readonly NorthwindContext _context;

        public OrderRepository(NorthwindContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            return await _context.Orders.FindAsync(id);
        }

        public async Task<IEnumerable<Order>> FindAsync(Expression<Func<Order, bool>> predicate)
        {
            return await _context.Orders.Where(predicate).ToListAsync();
        }

        public async Task AddAsync(Order entity)
        {
            await _context.Orders.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task AddRangeAsync(IEnumerable<Order> entities)
        {
            await _context.Orders.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }

        public void Remove(Order entity)
        {
            _context.Orders.Remove(entity);
            _context.SaveChanges();
        }

        public void RemoveRange(IEnumerable<Order> entities)
        {
            _context.Orders.RemoveRange(entities);
            _context.SaveChanges();
        }

        // Additional method to calculate the bill for an order
        public decimal CalculateBill(Order order)
        {
            decimal billAmount = order.TotalAmount * 1.1m; // Adding 10% tax
            return billAmount;
        }
    }
}
