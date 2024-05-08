using System.Collections.Generic;

namespace EKART.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        
        public virtual ICollection<Order> Orders { get; set; }
    }
}