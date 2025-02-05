using Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CartItemEntity = PizzaProjectApi.Domain.Entities.CartItem;

namespace PizzaProjectApi.Application.CartItem
{
    public interface ICartItemRepository
    {
        Task<Result<int>> AddCartItem(CartItemEntity cartItem);
    }
}
