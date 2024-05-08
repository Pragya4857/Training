using System;
using System.Threading.Tasks;
using EKART.Models;
using EKART.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EKART.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        // Display the customer details by order date
        public async Task<IActionResult> CustomerDetailsByOrderDate(DateTime orderDate)
        {
            var customers = await _customerRepository.GetCustomersByOrderDateAsync(orderDate);
            return View(customers);
        }

        // Show the customer who placed the highest order
        public async Task<IActionResult> CustomerWithHighestOrder()
        {
            var customer = await _customerRepository.GetCustomerWithHighestOrderAsync();
            return View(customer);
        }
    }
}
