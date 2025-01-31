using PizzaProjectApi.Application.Category.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CategoryEntity = PizzaProjectApi.Domain.Entities.Category;

namespace PizzaProjectApi.Application.Category
{
    public interface ICategoryRepository
    {
        Task<List<CategoryEntity>> GetCategoriesWithProducts();

        Task<List<CategoryGetDto>> GetCategories();
    }
}
