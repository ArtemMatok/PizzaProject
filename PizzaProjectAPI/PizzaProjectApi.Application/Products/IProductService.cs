using AutoMapper;
using PizzaProjectApi.Application.Products.DTOs;
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
        Task<Result<List<ProductSearchDto>>> GetProductsBySearch(string searchQuery);
    }
    public class ProductService(
        IProductRepository _productRepository
    ) : IProductService
    {
        public async Task<Result<List<ProductSearchDto>>> GetProductsBySearch(string searchQuery)
        {
            var products = await _productRepository.GetProductsBySearch(searchQuery);
            
            return Result<List<ProductSearchDto>>.Success(products);
        }
    }
}
