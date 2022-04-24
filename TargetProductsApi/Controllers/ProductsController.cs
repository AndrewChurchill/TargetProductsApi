using Microsoft.AspNetCore.Mvc;
using TargetProductsApi.Common.Products;
using TargetProductsApi.Products.GetProduct;
using TargetProductsApi.Products.UpdateProductPrice;
using TargetProductsApi.Validators.Products;

namespace TargetProductsApi.Controllers;

[ApiController]
[Route("/products")]
public class ProductsController : ControllerBase
{
    private readonly IGetProductAction _getProductAction;
    private readonly IUpdateProductPriceAction _updateProductPriceAction;

    public ProductsController(
        IGetProductAction getProductAction,
        IUpdateProductPriceAction updateProductPriceAction)
    {
        _getProductAction = getProductAction ??
            throw new ArgumentNullException(nameof(getProductAction));

        _updateProductPriceAction = updateProductPriceAction ??
            throw new ArgumentNullException(nameof(updateProductPriceAction));
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

        Product product = await _getProductAction.GetProduct(id);
        return await Task.FromResult(Ok(product));
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
        await _updateProductPriceAction.UpdateProductPrice(id, product.CurrentPrice);
        return await Task.FromResult(Ok());
    }
}
