using Newtonsoft.Json.Linq;
using TargetProductsApi.Common.Products;

namespace TargetProductsApi.Products;

public static class ProductItemEncoder
{
    public static Product Encode(string json)
    {
        JObject jObject = JObject.Parse(json);

        return new Product
        {
            Id = int.Parse(jObject["data"]["product"]["tcin"].ToString()),
            Name = jObject["data"]["product"]["item"]["product_description"]["title"].ToString(),
        };
    }
}
