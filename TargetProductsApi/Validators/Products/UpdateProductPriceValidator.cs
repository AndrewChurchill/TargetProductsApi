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
    }
}
