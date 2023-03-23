namespace BonsaiTreeShop.Shared.DTOs;

public record OrderDto(string ShipAddress, DateTime CreatedAt, OrderDetailsDto OrderDetails, string UserId);