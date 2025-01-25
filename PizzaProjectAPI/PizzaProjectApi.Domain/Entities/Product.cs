using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaProjectApi.Domain.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        //Relation
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<ProductVariant> ProductVariants { get; set; }
    }
}
