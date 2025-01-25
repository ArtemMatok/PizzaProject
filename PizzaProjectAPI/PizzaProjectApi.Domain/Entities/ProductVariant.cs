using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaProjectApi.Domain.Entities
{
    public class ProductVariant
    {
        public int ProductVariantId { get; set; }
        public decimal Price { get; set; }
        public int? Size { get; set; }
        public int? PizzaType { get; set; }
        //Relation
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public List<CartItem> CartItems { get; set; }   
    }
}
