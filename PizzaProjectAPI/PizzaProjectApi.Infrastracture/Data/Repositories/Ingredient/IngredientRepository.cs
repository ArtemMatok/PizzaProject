using Microsoft.EntityFrameworkCore;
using PizzaProjectApi.Application.Ingredients;
using PizzaProjectApi.Application.Ingredients.DTOs;
using PizzaProjectApi.Domain.Entities;
using Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaProjectApi.Infrastracture.Data
{
    public class IngredientRepository(ApplicationDbContext _context) : IIngredientRepository
    {
        public async Task<List<IngredientGetDto>> GetIngredientsAsync()
        {
            return await _context.Ingredients
                .Select(x => new IngredientGetDto(x.IngredientId, x.Name, x.ImageUrl, x.Price))
                .ToListAsync();
        }

        public async Task<List<IngredientBasicDto>> GetIngredientsBasicAsync()
        {
            return await _context.Ingredients
                .Select(x => new IngredientBasicDto(x.IngredientId, x.Name))
                .ToListAsync();
        }

        public async Task<List<Ingredient>> GetIngredientsByIds(List<int> ingredientsId)
        {
            return await _context.Ingredients
                .Where(x => ingredientsId.Contains(x.IngredientId))
                .ToListAsync();
        }
    }
}
