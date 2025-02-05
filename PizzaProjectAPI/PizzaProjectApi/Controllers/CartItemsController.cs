using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaProjectApi.Application.CartItem;
using PizzaProjectApi.Application.CartItem.DTOs;
using Response;

namespace PizzaProjectApi.Controllers
{
    [Route("api/cart-items")]
    [ApiController]
    public class CartItemsController(ICartItemService _cartItemService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateCartItem(CartItemCreateDto cartItemCreateDto)
        {
            var result = await _cartItemService.AddCartItem(cartItemCreateDto);

            return result.ToResponse();
        }
    }
}
