using TsKids.Application.DTOs;
using TsKids.Domain.Interfaces;

namespace TsKids.Application.UseCases.Categories;

public class GetCategoriesUseCase(ICategoryRepository repo)
{
    public async Task<IEnumerable<CategoryDto>> ExecuteAsync(CancellationToken ct = default)
    {
        var cats = await repo.GetAllAsync(ct);
        return cats.Select(c => new CategoryDto(c.Id, c.Name, c.Description, c.ImageUrl));
    }
}
