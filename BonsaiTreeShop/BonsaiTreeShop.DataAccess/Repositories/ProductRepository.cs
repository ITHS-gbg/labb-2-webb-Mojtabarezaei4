using BonsaiTreeShop.DataAccess.Data;
using BonsaiTreeShop.DataAccess.Model;
using BonsaiTreeShop.DataAccess.Repositories.Interfaces;
using BonsaiTreeShop.DataAccess.Services;
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
        var products = await _dataContext.Products.ToListAsync();

        return products.Select(Converter.ConvertToProductDto).ToList();
    }

    public async Task<ProductDto?> GetByIdAsync(object id)
    {
        var product = await _dataContext.Products.FirstOrDefaultAsync(p => p.Id == (Guid)id);
        return product is not null ? Converter.ConvertToProductDto(product) : null;
    }

    public async Task<ProductDto?> AddAsync(ProductDto productDto)
    {
        var result = await _dataContext.Products
            .AddAsync(Converter.ConvertToProductModel(productDto));
        return new ProductDto(result.Entity.Id, result.Entity.Name, 
            result.Entity.Description, result.Entity.Price, 
            result.Entity.Image, result.Entity.Category);
    }

    public async Task<ProductDto?> UpdateAsync(ProductDto product, object id)
    {
        var existingProduct = await _dataContext.Products.FirstOrDefaultAsync(p => p.Id == (Guid)id);
        if (existingProduct is null) return null;
        existingProduct.Name = product.Name;
        existingProduct.Category = product.Category;
        existingProduct.Description = product.Description;
        existingProduct.Image = product.Image;
        existingProduct.Price = product.Price;
        return product;
    }

    public async Task<ProductDto?> DeleteByIdAsync(object id)
    {
        var existingProduct = await _dataContext.Products.FirstOrDefaultAsync(p => p.Id == (Guid)id);
        
        if (existingProduct is null) return null;

        _dataContext.Products.Remove(existingProduct);
        
        return Converter.ConvertToProductDto(existingProduct);
    }

    private ProductDto ConvertToDto(Product product)
    {
        return new ProductDto(
            product.Id,
            product.Name,
            product.Description,
            product.Price,
            product.Image,
            product.Category
        );
    }

    private Product ConvertToModel(ProductDto productDto)
    {
        return new Product()
        {
            Name = productDto.Name,
            Description = productDto.Description,
            Price = productDto.Price,
            Image = productDto.Image,
            Category = productDto.Category
        };
    }
}