using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using TargetProductsApi.Common.Products;

namespace TargetProductsApi.Products;

public class MongoProductPriceStorageClient : IProductPriceStorageClient
{
    private readonly IMongoClient _client;

    public MongoProductPriceStorageClient(IMongoClient client)
    {
        _client = client ?? throw new ArgumentNullException(nameof(client));
    }

    public async Task<ProductPrice> GetProductPrice(int id)
    {
        IMongoDatabase database = _client.GetDatabase("targetProductPriceDb");
        IMongoCollection<BsonDocument> collection = database.GetCollection<BsonDocument>("prices");

        FilterDefinition<BsonDocument> filter = Builders<BsonDocument>.Filter.Eq("tcin", id);
        BsonDocument document = (await collection.FindAsync(filter)).FirstOrDefault();

        if (document is null)
        {
            return null;
        }

        return BsonSerializer.Deserialize<ProductPrice>(document);
    }

    public async Task UpdateProductPrice(int id, ProductPrice productPrice)
    {
        IMongoDatabase database = _client.GetDatabase("targetProductPriceDb");
        IMongoCollection<BsonDocument> collection = database.GetCollection<BsonDocument>("prices");

        FilterDefinition<BsonDocument> filter = Builders<BsonDocument>.Filter.Eq("tcin", id);
        BsonDocument existing = (await collection.FindAsync(filter)).FirstOrDefault();

        if (existing is null)
        {
            await collection.InsertOneAsync(new BsonDocument
            {
                { "tcin", id },
                { "value", productPrice.Value },
                { "currencyCode", productPrice.CurrencyCode },
            });
        }
        else
        {
            UpdateDefinition<BsonDocument> update = Builders<BsonDocument>.Update
                .Set("value", productPrice.Value)
                .Set("currencyCode", productPrice.CurrencyCode);

            await collection.UpdateOneAsync(filter, update);
        }
    }
}
