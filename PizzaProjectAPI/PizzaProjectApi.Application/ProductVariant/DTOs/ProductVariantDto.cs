using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaProjectApi.Application.ProductVariant.DTOs
{
    public record ProductVariantDto(
        int ProductVariantId,
        decimal Price,
        int? Size,
        int? PizzaType
    );

}
