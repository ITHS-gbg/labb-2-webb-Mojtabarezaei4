namespace BonsaiTreeShop.Shared.DTOs;

public class CartItem
{
    public Guid ProductId { get; set; }
    public string ProductName { get; set; }
    public string ProductDescription { get; set; }
    public decimal Price { get; set; }
    public string Image { get; set; }
    public string ProductCategory { get; set; }
    public int Quantity { get; set; }
}