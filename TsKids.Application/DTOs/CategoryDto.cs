namespace TsKids.Application.DTOs;

public record CategoryDto(
    Guid Id,
    string Name,
    string Description,
    string ImageUrl
);
