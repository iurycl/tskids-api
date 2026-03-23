using Microsoft.AspNetCore.Mvc;
using TsKids.Application.UseCases.Products;

namespace TsKids.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController(
    GetProductsUseCase getProducts,
    GetProductByIdUseCase getById) : ControllerBase
{
    /// <summary>Lista produtos com filtros e paginação</summary>
    [HttpGet]
    public async Task<IActionResult> GetAll(
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 20,
        [FromQuery] Guid? categoryId = null,
        [FromQuery] string? search = null,
        CancellationToken ct = default)
    {
        var result = await getProducts.ExecuteAsync(page, pageSize, categoryId, search, ct);
        return Ok(result);
    }

    /// <summary>Retorna um produto pelo ID</summary>
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken ct)
    {
        var product = await getById.ExecuteAsync(id, ct);
        return product is null ? NotFound() : Ok(product);
    }
}
