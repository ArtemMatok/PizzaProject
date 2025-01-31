﻿using AutoMapper;
using PizzaProjectApi.Application.Category.DTOs;
using PizzaProjectApi.Application.Ingredients.DTOs;
using PizzaProjectApi.Application.Products.DTOs;
using PizzaProjectApi.Application.ProductVariant;
using PizzaProjectApi.Domain.Entities;
using PizzaProjectApi.Application.Cart.DTOs;
using CategoryEntity = PizzaProjectApi.Domain.Entities.Category;
using ProductVariantEntity = PizzaProjectApi.Domain.Entities.ProductVariant;
using CartEntity = PizzaProjectApi.Domain.Entities.Cart;
using CartItemEntity = PizzaProjectApi.Domain.Entities.CartItem;
using PizzaProjectApi.Application.CartItem;

namespace PizzaProjectApi.Application.Shared
{
    public class SharedMapper : Profile
    {
        public SharedMapper()
        {
            CreateMap<Product, ProductGetDto>();
            CreateMap<Product, ProductBasicDto>();

            CreateMap<Ingredient, IngredientGetDto>();

            CreateMap<CategoryEntity, CategoryWithProductsDto>();

            CreateMap<ProductVariantEntity, ProductVariantDto>();

            CreateMap<CartEntity, CartGetDto>();

            CreateMap<CartItemEntity, CartItemGetDto>();

            CreateMap<Ingredient, IngredientBasicDto>();
        }
    }
}
