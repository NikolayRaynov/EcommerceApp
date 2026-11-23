using EcommerceApp.Services.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.Controllers.Api;

[ApiController]
[Route("api/v1/products")]
[Produces("application/json")]
public class ProductsApiController : ControllerBase
{
    private readonly IProductService productService;

    public ProductsApiController(IProductService productService)
    {
        this.productService = productService;
    }

    /// <summary>Returns a paginated list of products, optionally filtered by category.</summary>
    [HttpGet]
    [ProducesResponseType(typeof(ProductPageResponse), StatusCodes.Status200OK)]
    public async Task<ActionResult<ProductPageResponse>> GetAll(
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 10,
        [FromQuery] int? categoryId = null)
    {
        if (page < 1)
        {
            return BadRequest(new { message = "Page must be greater than zero." });
        }

        if (pageSize < 1 || pageSize > 50)
        {
            return BadRequest(new { message = "Page size must be between 1 and 50." });
        }

        var result = await productService.GetAllProductsAsync(page, pageSize, categoryId);
        return Ok(new ProductPageResponse(
            result.PageNumber,
            result.PageSize,
            result.TotalCount,
            result.TotalPages,
            result.Products.Select(product => new ProductResponse(
                product.Id,
                product.Name,
                product.Description,
                product.Price,
                product.ImageUrls,
                product.CreatedOn))));
    }

    /// <summary>Returns a product by its identifier.</summary>
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(ProductResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ProductResponse>> GetById(int id)
    {
        if (id < 1)
        {
            return BadRequest(new { message = "Product id must be greater than zero." });
        }

        var product = await productService.GetProductByIdAsync(id);
        if (product == null)
        {
            return NotFound();
        }

        return Ok(new ProductResponse(
            product.Id,
            product.Name,
            product.Description,
            product.Price,
            product.ImageUrls,
            product.CreatedOn));
    }
}

public sealed record ProductResponse(
    int Id,
    string Name,
    string Description,
    decimal Price,
    IReadOnlyCollection<string> ImageUrls,
    DateTime CreatedOn);

public sealed record ProductPageResponse(
    int Page,
    int PageSize,
    int TotalCount,
    int TotalPages,
    IEnumerable<ProductResponse> Items);
