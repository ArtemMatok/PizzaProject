using AutoMapper;
using PizzaProjectApi.Application.Cart.DTOs;
using PizzaProjectApi.Application.CartItem;
using PizzaProjectApi.Application.Ingredients;
using PizzaProjectApi.Application.Shared.Services;
using PizzaProjectApi.Domain.Entities;
using Response;
using CartEntity = PizzaProjectApi.Domain.Entities.Cart;

namespace PizzaProjectApi.Application.Cart
{
    public interface ICartService
    {
        Task<Result<string>> CreateCartForAnonymousUser();
        Task<Result<CartGetDto>> GetCartByToken(string cartToken);
        Task<Result<bool>> UpdateCartTotalAmount(string tokenCart);
    }

    public class CartService(
        ICartRepository _cartRepository,
        ICalculateService _calculateService,
        IMapper _mapper
    ) : ICartService
    {
        public async Task<Result<string>> CreateCartForAnonymousUser()
        {
            return await _cartRepository.CreateCartForAnonymousUser();
        }

        public async Task<Result<CartGetDto>> GetCartByToken(string cartToken)
        {
            if (string.IsNullOrEmpty(cartToken)) return Result<CartGetDto>.Failure("Cart token is required");

            var cartResult = await _cartRepository.GetCartFullByToken(cartToken);
            if (!cartResult.IsSuccess) return Result<CartGetDto>.Failure(cartResult.ErrorMessage);

            return Result<CartGetDto>.Success(_mapper.Map<CartGetDto>(cartResult.Value));
        }

        public async Task<Result<bool>> UpdateCartTotalAmount(string tokenCart)
        {
            if (string.IsNullOrEmpty(tokenCart))
            {
                return Result<bool>.Failure("Token is required.");
            }

            var cart = await _cartRepository.GetCartFullByToken(tokenCart);
            if (!cart.IsSuccess) return Result<bool>.Failure(cart.ErrorMessage);

            cart.Value.TotalAmount = _calculateService.CalculateTotalAmount(cart.Value);

            var updateResult = await _cartRepository.UpdateTotalAmountCart(cart.Value);
            if (!updateResult.IsSuccess) return Result<bool>.Failure(updateResult.ErrorMessage);

            return Result<bool>.Success(true);
        }
    }

}
