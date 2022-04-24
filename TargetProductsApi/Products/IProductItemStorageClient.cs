using TargetProductsApi.Common.Products;

namespace TargetProductsApi.Products;

public interface IProductItemStorageClient
{
    Task<Product> GetProduct(int id);
}
