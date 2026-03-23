namespace TsKids.Application.DTOs;

public record ProductDto(
    Guid Id,
    string Name,
    string Description,
    decimal Price,
    string ImageUrl,
    string Brand,
    int Stock,
    Guid CategoryId,
    string CategoryName,
    DateTime CreatedAt
);

public record ProductListItemDto(
    Guid Id,
    string Name,
    decimal Price,
    string ImageUrl,
    string Brand,
    Guid CategoryId,
    string CategoryName,
    int Stock
);

public record PagedResultDto<T>(
    IEnumerable<T> Data,
    int TotalCount,
    int Page,
    int PageSize,
    int TotalPages
);
