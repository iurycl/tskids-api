using Microsoft.EntityFrameworkCore;
using TsKids.Domain.Entities;
using TsKids.Domain.Interfaces;
using TsKids.Infrastructure.Data;

namespace TsKids.Infrastructure.Repositories;

public class CategoryRepository(TsKidsDbContext db) : ICategoryRepository
{
    public async Task<IEnumerable<Category>> GetAllAsync(CancellationToken ct = default) =>
        await db.Categories.AsNoTracking().OrderBy(c => c.Name).ToListAsync(ct);

    public async Task<Category?> GetByIdAsync(Guid id, CancellationToken ct = default) =>
        await db.Categories.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id, ct);
}
