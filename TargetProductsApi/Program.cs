using TargetProductsApi.Products;
using TargetProductsApi.Products.GetProduct;
using TargetProductsApi.Products.UpdateProductPrice;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Would eventually want to get this from environment variables.
string redSkyUrl = builder.Configuration.GetValue<string>("RedSkyConnection:Url");
string redSkyKey = builder.Configuration.GetValue<string>("RedSkyConnection:Key");

// Set up dependency injection.
builder.Services.AddSingleton<IProductItemStorageClient>(
    new RedSkyProductItemStorageClient(redSkyUrl, redSkyKey));

builder.Services.AddSingleton<IProductRepository, ProductRepository>();
builder.Services.AddSingleton<IGetProductAction, GetProductAction>();
builder.Services.AddSingleton<IUpdateProductPriceAction, UpdateProductPriceAction>();

// Set up swagger and register controllers.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
