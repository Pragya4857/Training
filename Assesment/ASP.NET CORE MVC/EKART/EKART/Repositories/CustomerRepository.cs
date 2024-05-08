using EKART.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EKART.Repositories
{
    public class CustomerRepository : IRepository<Customer>
    {
        private readonly NorthwindContext _context;

        public CustomerRepository(NorthwindContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task<IEnumerable<Customer>> FindAsync(Expression<Func<Customer, bool>> predicate)
        {
            return await _context.Customers.Where(predicate).ToListAsync();
        }

        public async Task AddAsync(Customer entity)
        {
            await _context.Customers.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task AddRangeAsync(IEnumerable<Customer> entities)
        {
            await _context.Customers.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }

        public void Remove(Customer entity)
        {
            _context.Customers.Remove(entity);
            _context.SaveChanges();
        }

        public void RemoveRange(IEnumerable<Customer> entities)
        {
            _context.Customers.RemoveRange(entities);
            _context.SaveChanges();
        }

        // Additional method to find customers by order date
        public async Task<IEnumerable<Customer>> FindByOrderDateAsync(DateTime orderDate)
        {
            return await _context.Customers
                .Where(c => c.Orders.Any(o => o.OrderDate.Date == orderDate.Date))
                .ToListAsync();
        }

        // Additional method to find the customer who placed the highest order
        public async Task<Customer> FindCustomerWithHighestOrderAsync()
        {
            return await _context.Customers
                .OrderByDescending(c => c.Orders.Sum(o => o.TotalAmount))
                .FirstOrDefaultAsync();
        }
    }
}
