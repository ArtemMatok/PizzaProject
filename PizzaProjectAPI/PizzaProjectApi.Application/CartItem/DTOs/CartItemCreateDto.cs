using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaProjectApi.Application.CartItem.DTOs
{
    public record CartItemCreateDto(
        int Quantity,
        int ProductVariantId,
        string TokenCart,
        List<int>? IngredientsId
    );
}
