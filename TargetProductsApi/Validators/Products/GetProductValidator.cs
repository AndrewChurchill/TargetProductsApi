namespace TargetProductsApi.Validators.Products;

public static class GetProductValidator
{
    public static void Validate(int id)
    {
        if (id < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(id));
        }
    }
}
