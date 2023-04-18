using BonsaiTreeShop.Shared.DTOs;

namespace BonsaiTreeShop.Client.Services;

public interface IAddToCartService
{
    public List<OrderDetailsDto> CartItems { get; set; }
    public event Action? AddToCart;
    public Task BuyOnClickAsync(ProductDto product);
}