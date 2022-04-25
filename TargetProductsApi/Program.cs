using MongoDB.Driver;
using TargetProductsApi;
using TargetProductsApi.Products;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Would eventually want to get this from environment variables.
string redSkyUrl = builder.Configuration.GetValue<string>("RedSkyConnection:Url");
string redSkyKey = builder.Configuration.GetValue<string>("RedSkyConnection:Key");
string mongoConnectionString = builder.Configuration.GetValue<string>("DatabaseConnection:ConnectionString");

// Set up dependency injection.
builder.Services.AddSingleton<IProductItemStorageClient>(
    new RedSkyProductItemStorageClient(redSkyUrl, redSkyKey));

builder.Services.AddSingleton<IProductPriceStorageClient>(
    new MongoProductPriceStorageClient(new MongoClient(mongoConnectionString)));

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
