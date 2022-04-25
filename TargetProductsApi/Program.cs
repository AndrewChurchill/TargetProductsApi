using MongoDB.Driver;
using TargetProductsApi;
using TargetProductsApi.Common.Configuration;
using TargetProductsApi.Products;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Would eventually want to get this from environment variables.
Configuration config = ConfigurationResolver.Resolve(builder.Configuration);

// Set up dependency injection.
builder.Services.AddSingleton<IProductItemStorageClient>(
    new RedSkyProductItemStorageClient(config.RedSkyUrl, config.RedSkyKey));

builder.Services.AddSingleton<IProductPriceStorageClient>(
    new MongoProductPriceStorageClient(new MongoClient(config.MongoConnection)));

builder.Services.AddSingleton<IProductRepository, ProductRepository>();

// Set up swagger and register controllers.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Set up exception handling middleware
builder.Services.AddControllers(options =>
{
    options.Filters.Add<HttpResponseExceptionFilter>();
});

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();
