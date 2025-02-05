using Microsoft.EntityFrameworkCore;
using PizzaProjectApi.Application.Cart;
using PizzaProjectApi.Domain.Entities;
using Response;
using CartEntity = PizzaProjectApi.Domain.Entities.Cart;

namespace PizzaProjectApi.Infrastracture.Data.Repositories.Cart
{
    public class CartRepository(ApplicationDbContext _context) : ICartRepository
    {
        public async Task<bool> CartExist(string cartToken)
        {
            var cart = await _context.Carts.FindAsync(cartToken);

            return cart is null ? false : true;
        }

        public async Task<Result<string>> CreateCartForAnonymousUser()
        {
            try
            {
                var cart = new CartEntity();

                await _context.Carts.AddAsync(cart);
                await _context.SaveChangesAsync();

                return Result<string>.Success(cart.TokenCart);
            }
            catch (Exception ex)
            {
                return Result<string>.Success(ex.Message);
            }
        }

        public async Task<Result<CartEntity>> GetCartFullByToken(string token)
        {
            var cart = await _context.Carts
                .AsNoTracking()
                .Include(x => x.CartItems)
                    .ThenInclude(ci => ci.ProductVariant)
                        .ThenInclude(pv => pv.Product)
                .Include(x => x.CartItems)
                    .ThenInclude(ci => ci.Ingredients)
                .AsSplitQuery()
                .FirstOrDefaultAsync(x => x.TokenCart == token);

            if (cart is null) return Result<CartEntity>.Failure("Cart wasn`t found");

            return Result<CartEntity>.Success(cart);
        }

        public async Task<Result<bool>> UpdateTotalAmountCart(CartEntity cart)
        {
            try
            {
                await _context.Carts
                    .Where(c => c.TokenCart == cart.TokenCart)
                    .ExecuteUpdateAsync(s =>
                        s.SetProperty(b => b.TotalAmount, cart.TotalAmount));

                return Result<bool>.Success(true);
            }
            catch (Exception ex)
            {
                return Result<bool>.Failure(ex.Message);
            }
        }
    }
}
