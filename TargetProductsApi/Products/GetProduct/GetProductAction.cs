using TargetProductsApi.Common.Products;

namespace TargetProductsApi.Products.GetProduct;

public class GetProductAction : IGetProductAction
{
    private readonly IProductRepository _productRepository;

    public GetProductAction(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Product> GetProduct(int id)
    {
        return await _productRepository.GetProduct(id);
    }
}
