using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaProjectApi.Domain.Entities
{
    public class Ingredient
    {
        public int IngredientId { get; set; }
        public string Name { get; set; }    
        public string ImageUrl { get; set; }
        public decimal Price { get;set; }
        //Relation
        public List<Product> Products { get; set; }
        public List<CartItem> CartItems { get; set; }
    }
}
