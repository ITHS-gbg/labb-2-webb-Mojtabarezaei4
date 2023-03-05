namespace BonsaiTreeShop.DataAccess.Model;

public class Order
{
    public Guid Id { get; set; }
    public User User { get; set; } = null!;
    public List<OrderDetail> OrderDetails { get; } = new List<OrderDetail>();
    public string ShipAddress { get; set; } = null!;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}