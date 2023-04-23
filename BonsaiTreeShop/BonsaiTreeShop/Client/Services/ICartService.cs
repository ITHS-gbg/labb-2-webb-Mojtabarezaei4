using BonsaiTreeShop.Shared.DTOs;

namespace BonsaiTreeShop.Client.Services;

public interface ICartService
{
    public List<CartItem> CartItems { get; set; }
    public int TotalCartItems { get; set; }
    public event Action? CartOnChange;
    public Task<List<CartItem>> GetCartItemsAsync();
    public Task BuyOnClickAsync(ProductDto product);
    public Task DecreaseQuantityAsync(CartItem cartItem);
    public Task IncreaseQuantityAsync(CartItem cartItem);
    public Task DeleteFromCartAsync(CartItem cartItem);
}