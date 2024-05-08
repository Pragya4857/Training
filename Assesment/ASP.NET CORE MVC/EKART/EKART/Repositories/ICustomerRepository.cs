using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EKART.Models;

namespace EKART.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<Customer> GetCustomerWithHighestOrderAsync();
        Task<IEnumerable<Customer>> GetCustomersByOrderDateAsync(DateTime orderDate);
    }
}
