using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaProjectApi.Domain.Entities
{
    public class CartItem
    {
        public int CartItemId { get; set; }
        public int Quantity { get; set; }

        //Relation
        public int ProductVariantId { get; set; }
        public ProductVariant ProductVariant { get; set; }
        public int CartId { get; set; }
        public Cart Cart { get;set; }   
        public List<Ingredient> Ingredients { get; set; }
    }
}
