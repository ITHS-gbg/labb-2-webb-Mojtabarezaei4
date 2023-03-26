using BonsaiTreeShop.Shared.DTOs;

namespace BonsaiTreeShop.Client.Services;

public interface IAddToCartService
{
    public Dictionary<ProductDto,int> Products { get; set; }

    public event Action? AddToCart;
    public void BuyOnClick(ProductDto product);
}