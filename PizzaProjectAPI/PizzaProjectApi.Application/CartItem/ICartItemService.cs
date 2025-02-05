using AutoMapper;
using PizzaProjectApi.Application.Cart;
using PizzaProjectApi.Application.CartItem.DTOs;
using PizzaProjectApi.Application.Ingredients;
using PizzaProjectApi.Application.ProductVariant;
using PizzaProjectApi.Application.Shared;
using Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CartItemEntity = PizzaProjectApi.Domain.Entities.CartItem;

namespace PizzaProjectApi.Application.CartItem
{
    public interface ICartItemService
    {
        Task<Result<int>> AddCartItem(CartItemCreateDto cartItemCreateDto);
    }

    public class CartItemService(
        ICartItemRepository _cartItemRepository,
        ICartRepository _cartRepository, 
        ICartService _cartService,
        IIngredientRepository _ingredientRepository,
        IProductVariantRepository _productVariantRepository,
        IUnitOfWork _unitOfWork,
        IMapper _mapper
    ) : ICartItemService
    {
        public async Task<Result<int>> AddCartItem(CartItemCreateDto cartItemCreateDto)
        {
            if(!await _cartRepository.CartExist(cartItemCreateDto.TokenCart))
            {
                return Result<int>.Failure("Cart wasn`t found");
            }

            if (!await _productVariantRepository.ProductVariantExist(cartItemCreateDto.ProductVariantId))
            {
                return Result<int>.Failure("Product variant wasn`t found");
            }

            var cartItem = _mapper.Map<CartItemEntity>(cartItemCreateDto);


            if (cartItemCreateDto.IngredientsId?.Count > 0)
            {
                cartItem.Ingredients = await _ingredientRepository.GetIngredientsByIds(cartItemCreateDto.IngredientsId);
            }

            await _unitOfWork.BeginTransactionAsync();
            try
            {
                var result = await _cartItemRepository.AddCartItem(cartItem);
                if (!result.IsSuccess)
                {
                    await _unitOfWork.RollbackTransactionAsync();
                    return Result<int>.Failure(result.ErrorMessage);
                }

                var cartUpdateResult = await _cartService.UpdateCartTotalAmount(cartItemCreateDto.TokenCart);
                if (!cartUpdateResult.IsSuccess)
                {
                    await _unitOfWork.RollbackTransactionAsync();
                    return Result<int>.Failure(cartUpdateResult.ErrorMessage);
                }

                await _unitOfWork.CommitTransactionAsync();
                return Result<int>.Success(result.Value);
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                return Result<int>.Failure($"An error occurred: {ex.Message}");
            }
        }
    }

}
