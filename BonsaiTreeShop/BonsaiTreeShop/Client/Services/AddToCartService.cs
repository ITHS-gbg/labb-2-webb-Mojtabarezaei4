using BonsaiTreeShop.Shared.DTOs;

namespace BonsaiTreeShop.Client.Services;

public class AddToCartService: IAddToCartService
{
    public event Action? AddToCart;

    public Dictionary<ProductDto, int> Products { get; set; } = new();

    public void BuyOnClick(ProductDto product)
    {
        if (Products.ContainsKey(product))
        {
            Products[product] ++;
        }
        else
        {
            Products.Add(product,1);
        }
        AddToCart?.Invoke();
    }
}