using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaProjectApi.Application.Products;
using Response;

namespace PizzaProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IProductService _productService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetProductsBySearchQuery([FromQuery] string? searchQuery)
        {
            var result = await _productService.GetProductsBySearch(searchQuery);
            return result.ToResponse();
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProductById(int productId)
        {
            var result = await _productService.GetProductById(productId);

            return result.ToResponse();
        }
    }
}
