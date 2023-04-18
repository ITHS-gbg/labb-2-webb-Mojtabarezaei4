using Blazored.LocalStorage;
using BonsaiTreeShop.Shared.DTOs;

namespace BonsaiTreeShop.Client.Services;

public class AddToCartService: IAddToCartService
{
    private readonly ILocalStorageService _localStorageService;
    public event Action? AddToCart;

    public List<OrderDetailsDto> CartItems { get; set; } = new();

    public AddToCartService(ILocalStorageService localStorageService)
    {
        _localStorageService = localStorageService;
    }
    public async Task BuyOnClickAsync(ProductDto product)
    {
        if (CartItems.Any(i => i.ProductId == product.Id))
        {
            var item = CartItems.First(i => i.ProductId == product.Id);
            item.Quantity++;
        }
        else
        {
            CartItems.Add(new ()
            {
                ProductId = product.Id,
                Quantity = 1
            });
        }

        await _localStorageService.SetItemAsync("cart", CartItems);
        AddToCart?.Invoke();
    }
}