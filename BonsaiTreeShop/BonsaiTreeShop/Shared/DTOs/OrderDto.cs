namespace BonsaiTreeShop.Shared.DTOs;

public class OrderDto
{ 
    public string ShipAddress { get; init; }
    public DateTime CreatedAt { get; init; }
    public IEnumerable<OrderDetailsDto> OrderDetails { get; init; }
    public string UserId { get; init; }
}