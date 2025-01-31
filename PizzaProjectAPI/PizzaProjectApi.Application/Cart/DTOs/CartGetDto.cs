using PizzaProjectApi.Application.CartItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PizzaProjectApi.Application.Cart.DTOs
{
    public record CartGetDto(
       int CartId,
       string Token,
       decimal TotalAmount,
       List<CartItemGetDto> CartItems
    );
}
