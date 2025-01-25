using PizzaProjectApi.Application.Category.DTOs;
using PizzaProjectApi.Application.Ingredients.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaProjectApi.Application.Products.DTOs
{
    public record ProductGetDto(
      int ProductId,
      string Name,
      string ImageUrl,
      int CategoryId,
      List<IngredientGetDto> Ingredients
    );
}
