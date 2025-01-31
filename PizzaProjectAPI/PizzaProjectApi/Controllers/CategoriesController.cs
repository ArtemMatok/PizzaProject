using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaProjectApi.Application.Category;

namespace PizzaProjectApi.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController(ICategoryService _categoryService) : ControllerBase
    {
        [HttpGet("categories-with-products")]
        public async Task<IActionResult> GetCategoriesWithProducts()
        {
            return Ok(await _categoryService.GetCategoriesWithProducts());
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            return Ok(await _categoryService.GetCategories());
        }
    }
}
