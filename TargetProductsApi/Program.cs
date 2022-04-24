using TargetProductsApi.Products;
using TargetProductsApi.Products.GetProduct;
using TargetProductsApi.Products.UpdateProductPrice;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Set up dependency injection.
builder.Services.AddSingleton<IProductItemStorageClient>(
    new RedSkyProductItemStorageClient(
        "https://redsky-uat.perf.target.com/redsky_aggregations/v1/redsky/case_study_v1",
        "3yUxt7WltYG7MFKPp7uyELi1K40ad2ys"));
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
