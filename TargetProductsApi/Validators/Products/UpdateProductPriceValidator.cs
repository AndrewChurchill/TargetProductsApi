using TargetProductsApi.Common.Products;

namespace TargetProductsApi.Validators.Products;

public static class UpdateProductPriceValidator
{
    public static void Validate(int id, Product product)
    {
        if (id < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(id));
        }

        if (product is null)
        {
            throw new ArgumentNullException(nameof(product));
        }

        if (product.CurrentPrice is null)
        {
            throw new InvalidOperationException("Current price is required.");
        }

        if (string.IsNullOrEmpty(product.CurrentPrice.CurrencyCode))
        {
            throw new InvalidOperationException("CurrencyCode is required.");
        }

        if (product.CurrentPrice.CurrencyCode.Length != 3)
        {
            throw new InvalidOperationException("CurrencyCode must be three characters.");
        }
    }
}
