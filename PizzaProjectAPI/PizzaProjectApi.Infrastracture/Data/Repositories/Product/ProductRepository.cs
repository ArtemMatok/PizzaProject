using Microsoft.EntityFrameworkCore;
using PizzaProjectApi.Application.Products;
using PizzaProjectApi.Application.Products.DTOs;
using PizzaProjectApi.Domain.Entities;
using Response;
using ProductEntity = PizzaProjectApi.Domain.Entities.Product;

namespace PizzaProjectApi.Infrastracture.Data.Repositories.Product
{
    public class ProductRepository(ApplicationDbContext _context) : IProductRepository
    {
        public async Task<Result<ProductEntity>> GetProductById(int productId)
        {
            try
            {
                var product = await _context.Products
                    .Include(x => x.Ingredients)
                    .Include(x => x.ProductVariants)
                    .FirstOrDefaultAsync(x => x.ProductId == productId);

                if (product is null) return Result<ProductEntity>.Failure("Product wasn`t found");

                return Result<ProductEntity>.Success(product);
            }
            catch (Exception ex)
            {
                return Result<ProductEntity>.Failure(ex.Message);
            }
        }

        public async Task<List<ProductBasicDto>> GetProductsBySearch(string searchQuery)
        {
            if (string.IsNullOrWhiteSpace(searchQuery))
            {
                return await _context.Products
                .Select(x => new ProductBasicDto(x.ProductId, x.Name, x.ImageUrl))
                .Take(5)
                .ToListAsync();
            }
            return await _context.Products
                .Where(x => x.Name.ToLower().Contains(searchQuery.ToLower()))
                .Select(x => new ProductBasicDto(x.ProductId, x.Name, x.ImageUrl))
                .ToListAsync();
        }
    }
}
