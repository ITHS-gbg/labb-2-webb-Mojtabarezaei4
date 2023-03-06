namespace BonsaiTreeShop.Shared.DTOs;

public record OrderDto(string ShipAddress, DateTime CreatedAt, ProductDto Product, int Quantity);