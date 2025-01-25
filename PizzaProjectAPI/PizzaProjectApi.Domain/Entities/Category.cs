using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaProjectApi.Domain.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string  Name { get; set; }
        //Relation
        public List<Product> Products { get; set; }
    }
}
