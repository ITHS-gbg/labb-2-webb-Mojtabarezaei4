using System.ComponentModel.DataAnnotations;

namespace BonsaiTreeShop.DataAccess.Model;

public class OrderDetail
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }

}