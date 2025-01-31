using AutoMapper;
using PizzaProjectApi.Application.Products.DTOs;
using PizzaProjectApi.Domain.Entities;
using Redis;
using Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaProjectApi.Application.Products
{
    public interface IProductService
    {
        Task<Result<List<ProductBasicDto>>> GetProductsBySearch(string searchQuery);
        Task<Result<ProductGetDto>> GetProductById(int productId);
    }
    public class ProductService(
        IProductRepository _productRepository,
        IRedisCacheService _cache,
        IMapper _mapper
    ) : IProductService
    {
        public async Task<Result<ProductGetDto>> GetProductById(int productId)
        {
            var cacheKey = $"Product_{productId}";
            var cacheProduct = await _cache.GetAsync<ProductGetDto>(cacheKey);

            if (cacheProduct != null)
            {
                return Result<ProductGetDto>.Success(cacheProduct);
            }

            var product = await _productRepository.GetProductById(productId);
            if (!product.IsSuccess) return Result<ProductGetDto>.Failure(product.ErrorMessage);

            var productDtoMapped = _mapper.Map<ProductGetDto>(product.Value);


            await _cache.SetAsync(cacheKey, productDtoMapped, TimeSpan.FromHours(1));

            return Result<ProductGetDto>.Success(productDtoMapped);
        }

        public async Task<Result<List<ProductBasicDto>>> GetProductsBySearch(string searchQuery)
        {
            var products = await _productRepository.GetProductsBySearch(searchQuery);
            
            return Result<List<ProductBasicDto>>.Success(products);
        }
    }
}
