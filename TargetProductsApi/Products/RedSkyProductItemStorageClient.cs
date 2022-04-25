using System.Net;
using Microsoft.AspNetCore.WebUtilities;
using TargetProductsApi.Common.Products;
using TargetProductsApi.Exceptions;

namespace TargetProductsApi.Products;

public class RedSkyProductItemStorageClient : IProductItemStorageClient
{
    private readonly string _url;
    private readonly string _key;
    private readonly HttpClient _client;

    public RedSkyProductItemStorageClient(string url, string key)
    {
        _url = url ?? throw new ArgumentNullException(nameof(url));
        _key = key ?? throw new ArgumentNullException(nameof(key));
        _client = new HttpClient();
    }

    public async Task<Product> GetProduct(int id)
    {
        string urlWithParams = QueryHelpers.AddQueryString(_url, new Dictionary<string, string>
        {
            { "tcin", id.ToString() },
            { "key", _key },
        });

        HttpResponseMessage response = await _client.GetAsync(urlWithParams);

        if (response.StatusCode == HttpStatusCode.NotFound)
        {
            throw new ResourceNotFoundException();
        }

        response.EnsureSuccessStatusCode();

        string productItem = await response.Content.ReadAsStringAsync();
        return ProductItemEncoder.Encode(productItem);
    }
}
