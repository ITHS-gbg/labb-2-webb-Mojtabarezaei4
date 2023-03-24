namespace BonsaiTreeShop.Shared.DTOs;

public record OrderDetailsDto(ProductDto ProductDto, int Quantity);