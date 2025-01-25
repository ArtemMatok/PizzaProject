using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Entities
{
    public enum OrderStatus
    {
        Pending,
        Succeeded,
        Cancelled
    }
    public class Order
    {
        public int OrderId { get; set; }
        public string UserId { get; set; }
        public string Token { get; set; } 
        public decimal TotalAmount { get; set; }
        public OrderStatus Status { get; set; }
        //It is CartItems from Cart.
        public string CartItem { get; set; }
        //Person infromation
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }   
        public string? Comment { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
