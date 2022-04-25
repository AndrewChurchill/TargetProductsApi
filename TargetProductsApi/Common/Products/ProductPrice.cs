using MongoDB.Bson.Serialization.Attributes;

namespace TargetProductsApi.Common.Products;

/// <summary>
/// Represents the price of a given product in the given currency.
/// </summary>
[BsonIgnoreExtraElements]
public class ProductPrice
{
    /// <summary>
    /// The current product's value in the given currency.
    /// </summary>
    [BsonElement("value")]
    public decimal Value { get; set; }

    /// <summary>
    /// The product value's currency code.
    /// </summary>
    [BsonElement("currencyCode")]
    public string CurrencyCode { get; set; }
}
