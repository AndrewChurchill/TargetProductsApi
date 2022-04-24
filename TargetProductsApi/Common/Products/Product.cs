namespace TargetProductsApi.Common.Products;

/// <summary>
/// Contains information about a given product.
/// </summary>
public class Product
{
    /// <summary>
    /// The ID of the product.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// The name of the product.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// The current price of the product.
    /// </summary>
    public ProductPrice CurrentPrice { get; set; }
}
