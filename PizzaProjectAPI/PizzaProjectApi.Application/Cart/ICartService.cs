using Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaProjectApi.Application.Cart
{
    public interface ICartService
    {
        Task<Result<string>> CreateCartForAnonymousUser();
    }

    public class CartService(ICartRepository _cartRepository) : ICartService
    {
        public async Task<Result<string>> CreateCartForAnonymousUser()
        {
            return await _cartRepository.CreateCartForAnonymousUser();
        }
    }

}
