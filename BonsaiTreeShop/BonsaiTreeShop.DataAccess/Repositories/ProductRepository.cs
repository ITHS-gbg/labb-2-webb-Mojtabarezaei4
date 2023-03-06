using BonsaiTreeShop.DataAccess.Data;
using BonsaiTreeShop.DataAccess.Model;
using BonsaiTreeShop.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BonsaiTreeShop.DataAccess.Repositories;

public class ProductRepository: IRepository<Product> 
{
    private readonly DataContext _dataContext;

    public ProductRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _dataContext.Products.ToListAsync();
    }

    public async Task<Product?> GetByIdAsync(object id)
    {
        var product = await _dataContext.Products.FirstOrDefaultAsync(p => p.Id == (Guid)id);
        return product ?? null;
    }

    public async Task<Product?> AddAsync(Product product)
    {
        await _dataContext.Products.AddAsync(product);
        return product;
    }

    public async Task<Product?> UpdateAsync(Product product)
    {
        var filter = await _dataContext.Products.FirstOrDefaultAsync(p => p.Id == product.Id);
        if (filter is null) return null;
        _dataContext.Products.Update(product);
        return product;
    }

    public async Task? DeleteByIdAsync(object id)
    {
        var filter = await _dataContext.Products.FirstOrDefaultAsync(p => p.Id == (Guid)id);
        if (filter is null) return;
        _dataContext.Products.Remove(filter);
    }
}