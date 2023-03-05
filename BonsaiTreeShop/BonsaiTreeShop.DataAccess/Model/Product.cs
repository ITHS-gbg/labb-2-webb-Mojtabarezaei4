using System.ComponentModel.DataAnnotations;

namespace BonsaiTreeShop.DataAccess.Model;

public class Product
{
    public Guid Id { get; set; }

    [StringLength(30)]
    [Required]
    public string Name { get; set; } = null!;

    public string Description { get; set; } = string.Empty;

    [Required]
    public int Price { get; set; }

    public string Image { get; set; } = string.Empty;

    [Required]
    public string Category { get; set; } = null!;

}