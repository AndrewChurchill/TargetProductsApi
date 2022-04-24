namespace TargetProductsApi.Common.Products;

/// <summary>
/// Represents the price of a given product in the given currency.
/// </summary>
public class ProductPrice
{
    /// <summary>
    /// The current product's value in the given currency.
    /// </summary>
    public decimal Value { get; set; }

    /// <summary>
    /// The product value's currency code.
    /// </summary>
    public string CurrencyCode { get; set; }
}
