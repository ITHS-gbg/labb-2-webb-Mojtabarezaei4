namespace BonsaiTreeShop.DataAccess.Model;

public class Stock
{
    public Guid Id { get; set; }
    public Product Product { get; set; } = null!;
    public int Quantity { get; set; }
    public bool Status { get; set; }
}