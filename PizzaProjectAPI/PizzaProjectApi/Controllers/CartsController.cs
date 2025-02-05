using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaProjectApi.Application.Cart;
using PizzaProjectApi.Application.CartItem.DTOs;
using Response;

namespace PizzaProjectApi.Controllers
{
    [Route("api/carts")]
    [ApiController]
    public class CartsController(ICartService _cartService) : ControllerBase
    {
        [HttpPost("create-cart-anonymous-user")]
        public async Task<IActionResult> CreateCartForAnonymousUser()
        {
            var result = await _cartService.CreateCartForAnonymousUser();

            return result.ToResponse();
        }

        [HttpGet("cart-by-token/{cartToken}")]
        public async Task<IActionResult> GetCartFullByToken(string cartToken)
        {
            var result = await _cartService.GetCartByToken(cartToken);

            return result.ToResponse();
        }
    }
}
