using AutoMapper;
using PizzaProjectApi.Application.Ingredients.DTOs;
using PizzaProjectApi.Application.Products.DTOs;
using PizzaProjectApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaProjectApi.Application.Shared
{
    public class SharedMapper : Profile
    {
        public SharedMapper()
        {
            CreateMap<Product, ProductGetDto>();
            CreateMap<Ingredient, IngredientGetDto>();
        }
    }
}
