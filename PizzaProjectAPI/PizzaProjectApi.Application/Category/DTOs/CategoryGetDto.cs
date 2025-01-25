using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaProjectApi.Application.Category.DTOs
{
    public record CategoryGetDto(
        int CategoryId,
        string Name
    );
}
