using Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CartEntity = PizzaProjectApi.Domain.Entities.Cart;

namespace PizzaProjectApi.Application.Cart
{
    public interface ICartRepository
    {
        Task<Result<string>> CreateCartForAnonymousUser();
        Task<Result<CartEntity>> GetCartByToken(string cartToken);
    }
}
