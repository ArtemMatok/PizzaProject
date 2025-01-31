using PizzaProjectApi.Application.Products.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaProjectApi.Application.ProductVariant
{
    public record ProductVariantGetDto(
        int ProductVariantId,
        decimal Price,
        int? Size,
        int? PizzaType,
        int ProductId,
        ProductBasicDto Product
    );
}
