using BonsaiTreeShop.DataAccess.Model;
using Microsoft.EntityFrameworkCore;

namespace BonsaiTreeShop.DataAccess.Data;

public class DataContext : DbContext 
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Stock> Stock { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Order> Orders { get; set; }
}