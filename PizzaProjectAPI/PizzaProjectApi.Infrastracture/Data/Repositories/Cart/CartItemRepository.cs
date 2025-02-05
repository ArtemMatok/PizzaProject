using PizzaProjectApi.Application.CartItem;
using PizzaProjectApi.Domain.Entities;
using Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaProjectApi.Infrastracture.Data.Repositories.Cart
{
    public class CartItemRepository(ApplicationDbContext _context) : ICartItemRepository
    {
        public async Task<Result<int>> AddCartItem(CartItem cartItem)
        {
            try
            {
                _context.CartItems.Add(cartItem);
                await _context.SaveChangesAsync();

                return Result<int>.Success(cartItem.CartItemId);
            }
            catch (Exception ex)
            {
                return Result<int>.Failure(ex.Message);
            }
        }
    }
}
