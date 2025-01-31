using Microsoft.EntityFrameworkCore;
using PizzaProjectApi.Application.Cart;
using PizzaProjectApi.Domain.Entities;
using Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaProjectApi.Infrastracture.Data
{
    public class CartRepository(ApplicationDbContext _context) : ICartRepository
    {
        public async Task<Result<string>> CreateCartForAnonymousUser()
        {
            try
            {
                var cart = new Cart();

                await _context.Carts.AddAsync(cart);
                await _context.SaveChangesAsync();

                return Result<string>.Success(cart.Token);
            }
            catch (Exception ex)
            {
                return Result<string>.Success(ex.Message);
            }
        }

        public async Task<Result<Cart>> GetCartByToken(string token)
        {
            var cart = await _context.Carts
                .AsNoTracking()
                .Include(x => x.CartItems)
                    .ThenInclude(ci => ci.ProductVariant)
                        .ThenInclude(pv => pv.Product)
                .Include(x => x.CartItems)
                    .ThenInclude(ci => ci.Ingredients)
                .AsSplitQuery()
                .FirstOrDefaultAsync(x => x.Token == token);

            if (cart is null) return Result<Cart>.Failure("Cart wasn`t found");

            return Result<Cart>.Success(cart);
        }
    }
}
