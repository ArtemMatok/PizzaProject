using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaProjectApi.Application.Products.DTOs
{
    public record ProductWithIngredientsWithPriceDto(
        int ProductId,
        string Name,
        string ImageUrl,
        decimal Price,
        List<string> Ingredients
    );
}
