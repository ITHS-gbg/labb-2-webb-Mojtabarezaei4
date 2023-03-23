namespace BonsaiTreeShop.Shared.DTOs;

public record OrderDetailsDto(IEnumerable<ProductDto> ProductDto, int Quantity);