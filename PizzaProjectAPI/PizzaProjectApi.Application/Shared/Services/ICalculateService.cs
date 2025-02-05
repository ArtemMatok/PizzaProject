using CartEntity = PizzaProjectApi.Domain.Entities.Cart;

namespace PizzaProjectApi.Application.Shared.Services
{
    public interface ICalculateService
    {
        decimal CalculateTotalAmount(CartEntity cart);
    }

    public class CalculateService : ICalculateService
    {
        public decimal CalculateTotalAmount(CartEntity cart)
        {
            if (cart.CartItems == null || !cart.CartItems.Any())
            {
                return 0;
            }

            var ingredientsSum = cart.CartItems.Sum(item =>
                item.Ingredients?.Sum(x => x.Price) ?? 0);

            var productVariantsSum = cart.CartItems.Sum(item =>
                item.ProductVariant.Price * item.Quantity);

            return ingredientsSum + productVariantsSum;
        }
    }

}
