using TsKids.Application.DTOs;
using TsKids.Domain.Interfaces;

namespace TsKids.Application.UseCases.Products;

public class GetProductByIdUseCase(IProductRepository repo)
{
    public async Task<ProductDto?> ExecuteAsync(Guid id, CancellationToken ct = default)
    {
        var p = await repo.GetByIdAsync(id, ct);
        if (p is null) return null;

        return new ProductDto(
            p.Id, p.Name, p.Description, p.Price, p.ImageUrl, p.Brand,
            p.Stock, p.CategoryId, p.Category?.Name ?? string.Empty, p.CreatedAt);
    }
}
