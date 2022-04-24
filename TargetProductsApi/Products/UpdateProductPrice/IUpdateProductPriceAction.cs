using TargetProductsApi.Common.Products;

namespace TargetProductsApi.Products.UpdateProductPrice;

public interface IUpdateProductPriceAction
{
    /// <summary>
    /// Updates the price of the given product.
    /// </summary>
    /// <param name="id">The ID of the product to update the price for.</param>
    /// <param name="price"><see cref="ProductPrice"/>.</param>
    /// <returns><see cref="Task"/>.</returns>
    Task<Product> UpdateProductPrice(int id, ProductPrice price);
}
