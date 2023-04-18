using Blazored.LocalStorage;
using BonsaiTreeShop.Shared.DTOs;

namespace BonsaiTreeShop.Client.Services;

public class AdjustCartService : IAdjustCartService
{
    private readonly ILocalStorageService _localStorageService;

    public AdjustCartService(ILocalStorageService localStorageService)
    {
        _localStorageService = localStorageService;
    }
    public async Task DecreaseQuantityAsync(ProductDto productDto)
    {
        var cart = await _localStorageService.GetItemAsync<List<OrderDetailsDto>>("cart");
        if (cart.First(ci => ci.ProductId == productDto.Id).Quantity >= 0)
            cart.First(ci => ci.ProductId == productDto.Id).Quantity--;
        if (cart.First(ci => ci.ProductId == productDto.Id).Quantity == 0)
            await DecreaseQuantityAsync(productDto);
        await _localStorageService.SetItemAsync<List<OrderDetailsDto>>("cart", cart);
    }

    public async Task IncreaseQuantityAsync(ProductDto productDto)
    {
        var cart = await _localStorageService.GetItemAsync<List<OrderDetailsDto>>("cart");
        cart.First(ci => ci.ProductId == productDto.Id).Quantity++;
        await _localStorageService.SetItemAsync<List<OrderDetailsDto>>("cart", cart);
    }

    public async Task DeleteFromCartAsync(ProductDto productDto)
    {
        var cart = await _localStorageService.GetItemAsync<List<OrderDetailsDto>>("cart");
        var orderDetailsDto = cart.First(ci => ci.ProductId == productDto.Id);
        cart.Remove(orderDetailsDto);
        if (!cart.Any())
            return;
        await _localStorageService.SetItemAsync<List<OrderDetailsDto>>("cart", cart);
    }
}