using PizzaProjectApi.Application.Products.DTOs;
using Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductEntity = PizzaProjectApi.Domain.Entities.Product;

namespace PizzaProjectApi.Application.Products
{
    public interface IProductRepository
    {
        Task<List<ProductBasicDto>> GetProductsBySearch(string searchQuery);
        Task<Result<ProductEntity>> GetProductById(int productId);

    }
}
