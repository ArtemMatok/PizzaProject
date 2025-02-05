using FluentValidation;
using PizzaProjectApi.Application.CartItem.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaProjectApi.Application.CartItem.Validators
{
    public class CartItemCreateDtoValidator : AbstractValidator<CartItemCreateDto>
    {
        public CartItemCreateDtoValidator()
        {
            RuleFor(x => x.TokenCart)
                .NotEmpty().WithMessage("Token cart is required");
            RuleFor(x => x.ProductVariantId)
                .NotNull().WithMessage("ProductVariantId is required");
            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("Quantity should be grater than 0");   
        }
    }
}
