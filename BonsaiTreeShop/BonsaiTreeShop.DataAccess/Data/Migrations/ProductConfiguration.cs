using BonsaiTreeShop.DataAccess.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BonsaiTreeShop.Server.Data.Migrations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasData(
            new Product
            {
                Name = "Japanese Maple Bonsai Tree",
                Category = "Maple",
                Description = "A beautiful Japanese Maple Bonsai Tree",
                Image = "https://www.bonsaitreegardener.net/wp-content/uploads/2015/04/japanese-maple-bonsai-tree.jpg",
                Price = 211,
                IsInStock = true
            },
            new Product
            {
                Name = "Juniper Bonsai",
                Category = "Juniper",
                Description = "The Juniper Bonsai trees that can be found in large stores, like Walmart and Home Depot, are often Japanese Garden Junipers, also known as Green Mound Junipers (Juniperus procumbens nana).",
                Image = "https://www.bonsaiempire.com/images/carrousel/Juniper01.jpg",
                Price = 3199,
                IsInStock = true
            }, new Product
            {
                Name = "Ficus Bonsai",
                Category = "Ficus",
                Description = "Depending on where you look, there is different information as to the exact number of existing Ficus tree species. We know that there may be between 800 and 2000 different species.",
                Image = "https://www.bonsaiempire.com/images/carrousel/ficus04-retusa-large.jpg",
                Price = 1999,
                IsInStock = true
            },
            new Product
            {
                Name = "Azalea Bonsai",
                Category = "Azalea",
                Description = "The Azalea is popular and well-known for its spectacular flowers, which open in late Spring and come in many different colors, shapes, sizes and patterns. In Japan special Azalea Bonsai festivals are organized around the time the trees flower.",
                Image = "https://www.bonsaiempire.com/images/carrousel/Azalea01-Satsuki-azalea.jpg",
                Price = 2999,
                IsInStock = true
            }, new Product
            {
                Name = "Azalea With Exposed Roots",
                Category = "Azalea",
                Description = "The Azalea is popular and well-known for its spectacular flowers, which open in late Spring and come in many different colors, shapes, sizes and patterns. In Japan special Azalea Bonsai festivals are organized around the time the trees flower.",
                Image = "https://www.bonsaiempire.com/images/carrousel/Azalea04-bonsai.jpg",
                Price = 4999,
                IsInStock = true
            },
            new Product
            {
                Name = "Olive Bonsai Cascade",
                Category = "Olive",
                Description = "Olive trees are well ramified evergreen trees or shrubs and, depending on the variety, can become up to 10 or even 20 meters (33 to 66 ft) tall. Wild olive trees, called oleaster, are smaller than cultivars.",
                Image = "https://www.bonsaiempire.com/images/carrousel/Olive04-bonsai.jpg",
                Price = 2999,
                IsInStock = true
            }
        );
    }
}