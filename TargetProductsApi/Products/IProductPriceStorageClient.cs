using TargetProductsApi.Common.Products;

namespace TargetProductsApi.Products;

public interface IProductPriceStorageClient
{
    Task<ProductPrice> GetProductPrice(int id);

    Task UpdateProductPrice(int id, ProductPrice productPrice);
}
