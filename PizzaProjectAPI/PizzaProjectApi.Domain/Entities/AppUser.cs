using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaProjectApi.Domain.Entities
{
    public class AppUser : IdentityUser
    {
        //Relation
        public int CartId { get; set; }
        public Cart Cart { get; set; }  
    }
}
