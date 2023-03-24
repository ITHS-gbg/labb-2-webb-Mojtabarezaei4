namespace BonsaiTreeShop.Shared.DTOs;

public record ProductDto(Guid Id, string Name, string Description, decimal Price, string Image, string Category);
