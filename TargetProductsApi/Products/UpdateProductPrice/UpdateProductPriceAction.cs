using TargetProductsApi.Common.Products;

namespace TargetProductsApi.Products.UpdateProductPrice;

public class UpdateProductPriceAction : IUpdateProductPriceAction
{
    public Task<Product> UpdateProductPrice(int id, ProductPrice price)
    {
        throw new NotImplementedException();
    }
}
