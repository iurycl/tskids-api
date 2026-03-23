using TsKids.Application.DTOs;
using TsKids.Domain.Interfaces;

namespace TsKids.Application.UseCases.Products;

public class GetProductsUseCase(IProductRepository repo)
{
    public async Task<PagedResultDto<ProductListItemDto>> ExecuteAsync(
        int page,
        int pageSize,
        Guid? categoryId,
        string? search,
        CancellationToken ct = default)
    {
        page = Math.Max(1, page);
        pageSize = Math.Clamp(pageSize, 1, 100);

        var (items, total) = await repo.GetPagedAsync(page, pageSize, categoryId, search, ct);

        var dtos = items.Select(p => new ProductListItemDto(
            p.Id, p.Name, p.Price, p.ImageUrl, p.Brand,
            p.CategoryId, p.Category?.Name ?? string.Empty, p.Stock));

        return new PagedResultDto<ProductListItemDto>(
            dtos, total, page, pageSize,
            (int)Math.Ceiling(total / (double)pageSize));
    }
}
