using PizzaProjectApi.Application.Ingredients.DTOs;
using PizzaProjectApi.Application.ProductVariant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaProjectApi.Application.CartItem
{
    public record CartItemGetDto(
        int CartItemId,
        int Quantity,
        int ProductVariantId,
        ProductVariantGetDto ProductVariant,
        List<IngredientBasicDto> Ingredients
    );
}
