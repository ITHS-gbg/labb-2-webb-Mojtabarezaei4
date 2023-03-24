namespace BonsaiTreeShop.Shared.DTOs;

public record OrderDto(string ShipAddress, DateTime CreatedAt, IEnumerable<OrderDetailsDto> OrderDetails, string UserId);