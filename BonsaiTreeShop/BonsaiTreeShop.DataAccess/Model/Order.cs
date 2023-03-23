namespace BonsaiTreeShop.DataAccess.Model;

public class Order
{
    public Guid Id { get; set; }
    public string UserId { get; set; } = null!;
    public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    public string ShipAddress { get; set; } = null!;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}