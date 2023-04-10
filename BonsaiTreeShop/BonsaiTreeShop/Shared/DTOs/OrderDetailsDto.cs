namespace BonsaiTreeShop.Shared.DTOs;

public class OrderDetailsDto
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}