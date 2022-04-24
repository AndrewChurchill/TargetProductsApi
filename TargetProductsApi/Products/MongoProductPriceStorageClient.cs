using TargetProductsApi.Common.Products;

namespace TargetProductsApi.Products;

public class MongoProductPriceStorageClient : IProductPriceStorageClient
{
    public Task<ProductPrice> GetProductPrice(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateProductPrice(int id, ProductPrice productPrice)
    {
        throw new NotImplementedException();
    }
}
