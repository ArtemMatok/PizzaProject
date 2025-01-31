using AutoMapper;
using PizzaProjectApi.Application.Category.DTOs;
using Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaProjectApi.Application.Category
{
    public interface ICategoryService
    {
        Task<List<CategoryWithProductsDto>> GetCategoriesWithProducts();
        Task<List<CategoryGetDto>> GetCategories();

    }

    public class CategoryService(
        ICategoryRepository _categoryRepository,
        IRedisCacheService _redisCacheService,
        IMapper _mapper
    ) : ICategoryService
    {
        public async Task<List<CategoryGetDto>> GetCategories()
        {
            return await _categoryRepository.GetCategories();
        }

        public async Task<List<CategoryWithProductsDto>> GetCategoriesWithProducts()
        {
            string cacheKey = "CategoriesWithProducts";

            var cachedCategories = await _redisCacheService.GetAsync<List<CategoryWithProductsDto>>(cacheKey);
            if (cachedCategories != null)
            {
                return cachedCategories;
            }

            var categories = await _categoryRepository.GetCategoriesWithProducts();
            var mappedCategories = _mapper.Map<List<CategoryWithProductsDto>>(categories);

            await _redisCacheService.SetAsync(cacheKey, mappedCategories, TimeSpan.FromHours(1));

            return mappedCategories;
        }
    }
}
