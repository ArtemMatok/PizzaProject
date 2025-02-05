using Microsoft.EntityFrameworkCore;
using PizzaProjectApi.Application.Category;
using PizzaProjectApi.Application.Category.DTOs;
using PizzaProjectApi.Application.Ingredients.DTOs;
using PizzaProjectApi.Application.Products.DTOs;
using PizzaProjectApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CategoryEntity = PizzaProjectApi.Domain.Entities.Category;

namespace PizzaProjectApi.Infrastracture.Data.Repositories.Category
{
    public class CategoryRepository(ApplicationDbContext _context) : ICategoryRepository
    {
        public async Task<List<CategoryGetDto>> GetCategories()
        {
            return await _context.Categories
                .Select(x => new CategoryGetDto(x.CategoryId, x.Name))
                .ToListAsync();
        }

        public async Task<List<CategoryEntity>> GetCategoriesWithProducts()
        {
            return await _context.Categories
                .Include(c => c.Products)
                    .ThenInclude(p => p.Ingredients)
                .Include(c => c.Products)
                    .ThenInclude(p => p.ProductVariants)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
