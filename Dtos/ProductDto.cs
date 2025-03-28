namespace Backend.Dtos;

public record ProductDto(
    Guid Id,
    string Name,
    string? Description,
    decimal Price,
    int StockQuantity,
    Guid CategoryId,
    DateTime CreatedAt,
    DateTime? UpdatedAt
);