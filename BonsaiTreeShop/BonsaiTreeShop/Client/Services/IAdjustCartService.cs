using BonsaiTreeShop.Shared.DTOs;

namespace BonsaiTreeShop.Client.Services;

public interface IAdjustCartService
{
    public Task DecreaseQuantityAsync(ProductDto productDto);
    public Task IncreaseQuantityAsync(ProductDto productDto);
    public Task DeleteFromCartAsync(ProductDto productDto);
}