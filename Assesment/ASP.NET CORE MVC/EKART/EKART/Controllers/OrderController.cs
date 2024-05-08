using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EKART.Models;
using EKART.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EKART.Controllers
{
    public class OrderController : Controller
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<Customer> _customerRepository;

        public OrderController(IRepository<Order> orderRepository, IRepository<Customer> customerRepository)
        {
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
        }

        // 1. Place the order
        public IActionResult PlaceOrder()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PlaceOrder(Order order)
        {
            if (ModelState.IsValid)
            {
                order.OrderDate = DateTime.Now; // Set current date as order date
                await _orderRepository.AddAsync(order);
                return RedirectToAction(nameof(OrderDetails), new { id = order.OrderId });
            }
            return View(order);
        }

        // 2. Show the order details
        public async Task<IActionResult> OrderDetails(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // 3. Display the bill with order id
        public async Task<IActionResult> DisplayBill(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            // Implement logic to calculate bill
            decimal billAmount = CalculateBill(order);
            ViewBag.BillAmount = billAmount;
            return View(order);
        }

        // 4. Display the customer details by order date
        public async Task<IActionResult> CustomerDetailsByOrderDate(DateTime orderDate)
        {
            var customers = await _customerRepository.GetAllAsync();
            var customerDetails = customers.Where(c => c.Orders.Any(o => o.OrderDate.Date == orderDate.Date));
            return View(customerDetails);
        }

        // 5. Show the customer who placed the highest order
        public async Task<IActionResult> CustomerWithHighestOrder()
        {
            var customers = await _customerRepository.GetAllAsync();
            var customerWithHighestOrder = customers.OrderByDescending(c => c.Orders.Sum(o => o.TotalAmount)).FirstOrDefault();
            return View(customerWithHighestOrder);
        }

        private decimal CalculateBill(Order order)
        {
            decimal billAmount = order.TotalAmount * 1.1m; // Adding 10% tax
            return billAmount;
        }
    }
}
