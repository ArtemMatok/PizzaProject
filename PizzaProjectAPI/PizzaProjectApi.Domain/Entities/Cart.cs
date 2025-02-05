using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaProjectApi.Domain.Entities
{
    public class Cart
    {
        [Key]
        public string TokenCart { get; set; } = Guid.NewGuid().ToString();
        public decimal TotalAmount { get; set; }
        //Relation
        [ForeignKey("User")]
        public string? UserId { get; set; }
        public AppUser? User { get; set; }
        public List<CartItem> CartItems { get; set; }
    }
}
