using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaProjectApi.Application.ProductVariant
{
    public interface IProductVariantRepository
    {
        Task<bool> ProductVariantExist(int productVariantId);
    }
}
