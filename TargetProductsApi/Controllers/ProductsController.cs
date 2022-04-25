using Microsoft.AspNetCore.Mvc;
using TargetProductsApi.Common.Products;
using TargetProductsApi.Products;
using TargetProductsApi.Validators.Products;

namespace TargetProductsApi.Controllers;

[ApiController]
[Route("/products")]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository _productRepository;

    public ProductsController(
        IProductRepository productRepository)
    {
        _productRepository = productRepository ??
            throw new ArgumentNullException(nameof(productRepository));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProduct(int id)
    {
        try
        {
            GetProductValidator.Validate(id);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

        Product product = await _productRepository.GetProduct(id);
        return Ok(product);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(int id, Product product)
    {
        try
        {
            UpdateProductPriceValidator.Validate(id, product);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

        // Only support updating product price for now.
        Product updated = await _productRepository.UpdateProductPrice(id, product.CurrentPrice);
        return Ok(updated);
    }
}
