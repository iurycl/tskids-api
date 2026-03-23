using Microsoft.AspNetCore.Mvc;
using TsKids.Application.UseCases.Categories;

namespace TsKids.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController(GetCategoriesUseCase getCategories) : ControllerBase
{
    /// <summary>Lista todas as categorias</summary>
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken ct)
    {
        var result = await getCategories.ExecuteAsync(ct);
        return Ok(result);
    }
}
