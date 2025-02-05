using Response;
using CartEntity = PizzaProjectApi.Domain.Entities.Cart;
using CartItemEntity = PizzaProjectApi.Domain.Entities.CartItem;


namespace PizzaProjectApi.Application.Cart
{
    public interface ICartRepository
    {
        Task<Result<string>> CreateCartForAnonymousUser();
        Task<Result<CartEntity>> GetCartFullByToken(string cartToken);
        Task<bool> CartExist(string cartToken);
        Task<Result<bool>> UpdateTotalAmountCart(CartEntity cart);
    }
}
