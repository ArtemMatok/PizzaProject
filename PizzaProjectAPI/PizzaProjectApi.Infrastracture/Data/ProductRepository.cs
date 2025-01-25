using Microsoft.EntityFrameworkCore;
using PizzaProjectApi.Application.Products;
using PizzaProjectApi.Application.Products.DTOs;
using PizzaProjectApi.Domain.Entities;
using Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaProjectApi.Infrastracture.Data
{
    public class ProductRepository(ApplicationDbContext _context) : IProductRepository
    {
        public async Task<List<ProductSearchDto>> GetProductsBySearch(string searchQuery)
        {
            if (String.IsNullOrWhiteSpace(searchQuery))
            {
                return await _context.Products
                .Select(x => new ProductSearchDto(x.ProductId, x.Name, x.ImageUrl))
                .Take(5)
                .ToListAsync();
            }
            return await _context.Products
                .Where(x => x.Name.ToLower().Contains(searchQuery.ToLower()))
                .Select(x => new ProductSearchDto(x.ProductId, x.Name, x.ImageUrl))
                .ToListAsync();
        }
    }
}
