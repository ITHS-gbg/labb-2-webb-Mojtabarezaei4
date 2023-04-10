namespace BonsaiTreeShop.Shared.DTOs;

public class ProductDto
{
    public Guid Id { get; init; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Image { get; set; }
    public string Category { get; set; }
    public bool IsInStock { get; set; }
}
