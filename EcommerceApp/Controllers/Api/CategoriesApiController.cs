using EcommerceApp.Services.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.Controllers.Api;

[ApiController]
[Route("api/v1/categories")]
[Produces("application/json")]
public class CategoriesApiController : ControllerBase
{
    private readonly ICategoryService categoryService;

    public CategoriesApiController(ICategoryService categoryService)
    {
        this.categoryService = categoryService;
    }

    /// <summary>Returns all product categories.</summary>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<CategoryResponse>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<CategoryResponse>>> GetAll()
    {
        var categories = await categoryService.GetAllAsync();
        return Ok(categories.Select(category => new CategoryResponse(category.Id, category.Name)));
    }

    /// <summary>Returns a category by its identifier.</summary>
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(CategoryResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CategoryResponse>> GetById(int id)
    {
        if (id < 1)
        {
            return BadRequest(new { message = "Category id must be greater than zero." });
        }

        var category = await categoryService.GetByIdAsync(id);
        if (category == null)
        {
            return NotFound();
        }

        return Ok(new CategoryResponse(category.Id, category.Name));
    }
}

public sealed record CategoryResponse(int Id, string Name);
