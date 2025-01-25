using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaProjectApi.Application.Ingredients;
using Response;

namespace PizzaProjectApi.Controllers
{
    [Route("api/ingredients")]
    [ApiController]
    public class IngredientsController(IIngredientService _ingredientService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetIngredientsAsync()
        {
            return Ok(await _ingredientService.GetIngredientsAsync());
        }

        [HttpGet("ingredients-basic")]
        public async Task<IActionResult> GetIngredientsBasicAsync()
        {
            return Ok(await _ingredientService.GetIngredientsBasicAsync());
        }
    }
}
