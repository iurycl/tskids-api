using Microsoft.EntityFrameworkCore;
using TsKids.Domain.Entities;
using TsKids.Domain.Interfaces;
using TsKids.Infrastructure.Data;

namespace TsKids.Infrastructure.Repositories;

public class ProductRepository(TsKidsDbContext db) : IProductRepository
{
    public async Task<(IEnumerable<Product> Items, int TotalCount)> GetPagedAsync(
        int page, int pageSize, Guid? categoryId, string? search, CancellationToken ct = default)
    {
        var query = db.Products
            .Include(p => p.Category)
            .AsNoTracking();

        if (categoryId.HasValue)
            query = query.Where(p => p.CategoryId == categoryId.Value);

        if (!string.IsNullOrWhiteSpace(search))
        {
            var term = search.ToLower();
            query = query.Where(p =>
                p.Name.ToLower().Contains(term) ||
                p.Description.ToLower().Contains(term) ||
                p.Brand.ToLower().Contains(term));
        }

        var total = await query.CountAsync(ct);
        var items = await query
            .OrderBy(p => p.Name)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(ct);

        return (items, total);
    }

    public async Task<Product?> GetByIdAsync(Guid id, CancellationToken ct = default) =>
        await db.Products
            .Include(p => p.Category)
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id, ct);
}
