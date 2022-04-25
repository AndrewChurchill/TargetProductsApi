using TargetProductsApi.Common.Products;
using TargetProductsApi.Exceptions;

namespace TargetProductsApi.Products;

public class ProductRepository : IProductRepository
{
    private readonly IProductItemStorageClient _productItemStorageClient;
    private readonly IProductPriceStorageClient _productPriceStorageClient;

    public ProductRepository(
        IProductItemStorageClient productItemStorageClient,
        IProductPriceStorageClient productPriceStorageClient)
    {
        _productItemStorageClient = productItemStorageClient
            ?? throw new ArgumentNullException(nameof(productItemStorageClient));

        _productPriceStorageClient = productPriceStorageClient
            ?? throw new ArgumentNullException(nameof(productPriceStorageClient));
    }

    public async Task<Product> GetProduct(int id)
    {
        Product product = await _productItemStorageClient.GetProduct(id);
        if (product is null)
        {
            throw new TargetResourceNotFoundException();
        }

        // Price can be null if it hasn't been set yet.
        ProductPrice price = await _productPriceStorageClient.GetProductPrice(id);
        product.CurrentPrice = price;

        return product;
    }

    public async Task<Product> UpdateProductPrice(int id, ProductPrice productPrice)
    {
        // Only want to update if the product exists
        Product existingProduct = await _productItemStorageClient.GetProduct(id);
        if (existingProduct is null)
        {
            throw new TargetResourceNotFoundException();
        }

        await _productPriceStorageClient.UpdateProductPrice(id, productPrice);
        return await GetProduct(id);
    }
}
