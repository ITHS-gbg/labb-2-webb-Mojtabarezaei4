namespace BonsaiTreeShop.DataAccess.Model;

public class OrderDetail
{
    public Guid Id { get; set; }
    public Order Order { get; set; } = null!;
    public Product Product { get; set; } = null!;
    public int Quantity { get; set; }

}