using TargetProductsApi.Common.Products;

namespace TargetProductsApi.Products.GetProduct;

public interface IGetProductAction
{
    /// <summary>
    /// Gets a product with the given ID.
    /// </summary>
    /// <param name="id">The ID of the product to find</param>
    /// <returns><see cref="Product"/>.</returns>
    Task<Product> GetProduct(int id);
}
