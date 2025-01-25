using PizzaProjectApi.Application.Ingredients.DTOs;
using Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaProjectApi.Application.Ingredients
{
    public interface IIngredientService
    {
        Task<List<IngredientGetDto>> GetIngredientsAsync();
        Task<List<IngredientBasicDto>> GetIngredientsBasicAsync();

    }
    public class IngredientService(IIngredientRepository _ingredientRepository) : IIngredientService
    {
        public async Task<List<IngredientGetDto>> GetIngredientsAsync()
        {
            return await _ingredientRepository.GetIngredientsAsync();
        }

        public async Task<List<IngredientBasicDto>> GetIngredientsBasicAsync()
        {
            return await _ingredientRepository.GetIngredientsBasicAsync();
        }
    }
}
