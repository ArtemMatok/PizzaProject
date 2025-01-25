using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaProjectApi.Application.Ingredients.DTOs
{
    public record IngredientGetDto(
        int IngredientId,
        string Name,
        string ImageUrl,
        decimal Price
    );
}
