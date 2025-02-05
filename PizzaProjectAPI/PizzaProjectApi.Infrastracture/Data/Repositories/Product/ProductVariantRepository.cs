using PizzaProjectApi.Application.ProductVariant;


namespace PizzaProjectApi.Infrastracture.Data.Repositories.Product
{
    public class ProductVariantRepository(ApplicationDbContext _context) : IProductVariantRepository
    {
        public async Task<bool> ProductVariantExist(int productVariantId)
        {
            var productVariant = await _context.Products.FindAsync(productVariantId);

            return productVariant is null ? false : true;
        }
    }
}
