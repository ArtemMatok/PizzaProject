using PizzaProjectApi.Application.Products.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaProjectApi.Application.Category.DTOs
{
    public record CategoryWithProductsDto(
        int CategoryId,
        string Name,
        List<ProductGetDto> Products
    );
}
