using TargetProductsApi.Common.Products;

namespace TargetProductsApi.Products;

public class ProductRepository : IProductRepository
{
    private readonly IProductItemStorageClient _productItemStorageClient;

    public ProductRepository(IProductItemStorageClient productItemStorageClient)
    {
        _productItemStorageClient = productItemStorageClient;
    }

    public Task<Product> GetProduct(int id)
    {
        return _productItemStorageClient.GetProduct(id);
    }

    public Task UpdateProductPrice(int id, ProductPrice productPrice)
    {
        throw new NotImplementedException();
    }
}
