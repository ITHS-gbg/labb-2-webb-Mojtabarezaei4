using Blazored.LocalStorage;
using BonsaiTreeShop.Shared.DTOs;

namespace BonsaiTreeShop.Client.Services;

public class CartService : ICartService
{
    private readonly ILocalStorageService _localStorageService;

    public int TotalCartItems { get; set; }
    public event Action? CartOnChange;

    public List<CartItem> CartItems { get; set; } = new();

    public CartService(ILocalStorageService localStorageService)
    {
        _localStorageService = localStorageService;
    }

    public async Task<List<CartItem>> GetCartItemsAsync()
    {
        var cart = await _localStorageService.GetItemAsync<List<CartItem>>("cart");
        if (cart == null)
        {
            return new List<CartItem>();
        }

        CartItems = cart;
        return cart;
    }

    public async Task BuyOnClickAsync(ProductDto product)
    {
        if (CartItems.Any(i => i.ProductId == product.Id))
        {
            var item = CartItems.First(i => i.ProductId == product.Id);
            item.Quantity++;
            TotalCartItems += item.Quantity;
        }
        else
        {
            CartItems.Add(new()
            {
                ProductId = product.Id,
                ProductName = product.Name,
                ProductDescription = product.Description,
                Image = product.Image,
                ProductCategory = product.Category,
                Price = product.Price,
                Quantity = 1
            });
            TotalCartItems += CartItems.FirstOrDefault(ci => ci.ProductId == product.Id)!.Quantity;
        }

        await _localStorageService.SetItemAsync("cart", CartItems);
        CartOnChange?.Invoke();
    }
    public async Task DecreaseQuantityAsync(CartItem cartItem)
    {
        if (CartItems.FirstOrDefault(ci => ci.ProductId == cartItem.ProductId)?.Quantity >= 0)
        {
            CartItems.First(ci => ci.ProductId == cartItem.ProductId).Quantity--;
            TotalCartItems -= CartItems.First(ci => ci.ProductId == cartItem.ProductId).Quantity;
        }

        if (CartItems.FirstOrDefault(ci => ci.ProductId == cartItem.ProductId)?.Quantity == 0)
            await DeleteFromCartAsync(cartItem);

        await _localStorageService.SetItemAsync("cart", CartItems);
        CartOnChange?.Invoke();
    }

    public async Task IncreaseQuantityAsync(CartItem cartItem)
    {
        if (CartItems.FirstOrDefault(ci => ci.ProductId == cartItem.ProductId)?.Quantity >= 0)
        {
            CartItems.First(ci => ci.ProductId == cartItem.ProductId).Quantity++;
            TotalCartItems += CartItems.First(ci => ci.ProductId == cartItem.ProductId).Quantity;
        }
        await _localStorageService.SetItemAsync("cart", CartItems);
        CartOnChange?.Invoke();
    }

    public async Task DeleteFromCartAsync(CartItem cartItem)
    {
        var orderDetailsDto = CartItems.FirstOrDefault(ci => ci.ProductId == cartItem.ProductId);
        if (orderDetailsDto is null) return;

        TotalCartItems -= CartItems.First(ci => ci.ProductId == cartItem.ProductId).Quantity;
        CartItems.Remove(orderDetailsDto!);

        if (!CartItems.Any())
        {
            await _localStorageService.RemoveItemAsync("cart");
            CartOnChange?.Invoke();
            return;
        }
        await _localStorageService.SetItemAsync("cart", CartItems);
        CartOnChange?.Invoke();
    }
}