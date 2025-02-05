using Microsoft.EntityFrameworkCore;
using PizzaProjectApi.Application.Category;
using PizzaProjectApi.Application.Ingredients;
using PizzaProjectApi.Application.Products;
using PizzaProjectApi.Application.Shared;
using PizzaProjectApi.Infrastracture.Data;
using Redis;
using System.Text.Json.Serialization;
using System.Text.Json;
using PizzaProjectApi.Application.Cart;
using PizzaProjectApi.Application.CartItem;
using FluentValidation;
using FluentValidation.AspNetCore;
using PizzaProjectApi.Application.CartItem.Validators;
using PizzaProjectApi.Application.ProductVariant;
using PizzaProjectApi.Application.Shared.Services;
using PizzaProjectApi.Infrastracture.Data.Repositories.Cart;
using PizzaProjectApi.Infrastracture.Data.Repositories.Product;
using PizzaProjectApi.Infrastracture.Data.Repositories.Category;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddAutoMapper(typeof(SharedMapper));
builder.Services.AddValidatorsFromAssemblyContaining<CartItemCreateDtoValidator>();
builder.Services.AddFluentValidationAutoValidation();


//Services
builder.Services.AddScoped<IIngredientService, IngredientService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<ICartItemService, CartItemService>();
builder.Services.AddScoped<ICalculateService, CalculateService>();
//Repositories
builder.Services.AddScoped<IIngredientRepository, IngredientRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddScoped<ICartItemRepository, CartItemRepository>();
builder.Services.AddScoped<IProductVariantRepository, ProductVariantRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();



//Redis
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("Redis");
});
builder.Services.AddSingleton<IRedisCacheService, RedisCacheService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials()
    .SetIsOriginAllowed(origin => true)
);

app.UseAuthorization();

app.MapControllers();

app.Run();
