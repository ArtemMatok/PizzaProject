using PizzaProjectApi.Application.CartItem.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PizzaProjectApi.Application.Cart.DTOs
{
    public record CartGetDto(
       string TokenCart,
       decimal TotalAmount,
       List<CartItemGetDto> CartItems
    );
}
