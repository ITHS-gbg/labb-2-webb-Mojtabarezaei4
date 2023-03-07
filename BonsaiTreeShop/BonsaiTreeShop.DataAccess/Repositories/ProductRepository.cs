using BonsaiTreeShop.DataAccess.Data;
using BonsaiTreeShop.DataAccess.Model;
using BonsaiTreeShop.DataAccess.Repositories.Interfaces;
using BonsaiTreeShop.Shared.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BonsaiTreeShop.DataAccess.Repositories;

public class ProductRepository : IRepository<ProductDto>
{
    private readonly DataContext _dataContext;

    public ProductRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<IEnumerable<ProductDto>> GetAllAsync()
    {
        var products = await _dataContext.Products
            .Select(p => new ProductDto(
                p.Name,
                p.Description,
                p.Price,
                p.Image,
                p.Category))
            .ToListAsync();

        return products;
    }

    public async Task<ProductDto?> GetByIdAsync(object id)
    {
        var product = await _dataContext.Products.FirstOrDefaultAsync(p => p.Id == (Guid)id);
        return product is not null ?
            new ProductDto(product.Name, product.Description, product.Price, product.Image, product.Category)
                   : null;
    }

    public async Task<ProductDto?> AddAsync(ProductDto productDto)
    {
        var newProduct = new Product()
        {
            Name = productDto.Name,
            Category = productDto.Category,
            Description = productDto.Description,
            Image = productDto.Image,
            Price = productDto.Price
        };
        await _dataContext.Products.AddAsync(newProduct);
        return productDto;
    }

    public async Task<ProductDto?> UpdateAsync(ProductDto product, object id)
    {
        var filter = await _dataContext.Products.FirstOrDefaultAsync(p => p.Name == product.Name);
        if (filter is null) return null;
        var newProduct = new Product()
        {
            Name = product.Name,
            Category = product.Category,
            Description = product.Description,
            Image = product.Image,
            Price = product.Price
        };
        _dataContext.Products.Update(newProduct);
        return product;
    }

    public async Task? DeleteByIdAsync(object id)
    {
        var filter = await _dataContext.Products.FirstOrDefaultAsync(p => p.Id == (Guid)id);
        if (filter is null) return;
        _dataContext.Products.Remove(filter);
    }
}