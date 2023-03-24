using System.ComponentModel.DataAnnotations;

namespace BonsaiTreeShop.DataAccess.Model;

public class Stock
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    public Product Product { get; set; } = null!;
    public int Quantity { get; set; }
    public bool Status { get; set; }
}