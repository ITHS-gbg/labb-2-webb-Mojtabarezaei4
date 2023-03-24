using System.ComponentModel.DataAnnotations;

namespace BonsaiTreeShop.DataAccess.Model;

public class Order
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    public string UserId { get; set; } = null!;
    public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    public string ShipAddress { get; set; } = null!;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}