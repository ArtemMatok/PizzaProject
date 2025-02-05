using PizzaProjectApi.Application.Ingredients.DTOs;
using PizzaProjectApi.Application.ProductVariant.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaProjectApi.Application.CartItem.DTOs
{
    public record CartItemGetDto(
        int CartItemId,
        string TokenCart,
        int Quantity,
        int ProductVariantId,
        ProductVariantGetDto ProductVariant,
        List<IngredientGetDto> Ingredients
    );
}
