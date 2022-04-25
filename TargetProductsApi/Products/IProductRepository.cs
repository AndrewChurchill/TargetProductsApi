using TargetProductsApi.Common.Products;

namespace TargetProductsApi.Products;

public interface IProductRepository
{
    Task<Product> GetProduct(int id);

    Task<Product> UpdateProductPrice(int id, ProductPrice productPrice);
}
