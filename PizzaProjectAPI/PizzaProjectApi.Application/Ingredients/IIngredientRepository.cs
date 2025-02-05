using PizzaProjectApi.Application.Ingredients.DTOs;
using Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngredientEntity = PizzaProjectApi.Domain.Entities.Ingredient;

namespace PizzaProjectApi.Application.Ingredients
{
    public interface IIngredientRepository
    {
        Task<List<IngredientGetDto>> GetIngredientsAsync();
        Task<List<IngredientBasicDto>> GetIngredientsBasicAsync();
        Task<List<IngredientEntity>> GetIngredientsByIds(List<int> ingredientsId);
    }
}
