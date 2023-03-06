using BonsaiTreeShop.DataAccess.Commands;
using BonsaiTreeShop.DataAccess.Model;
using BonsaiTreeShop.DataAccess.Repositories.Interfaces;
using MediatR;

namespace BonsaiTreeShop.DataAccess.Handlers;

public class AddProductHandler: IRequestHandler<AddProductCommand, Product>
{
    private readonly IRepository<Product> _repository;

    public AddProductHandler(IRepository<Product> repository)
    {
        _repository = repository;
    }

    public async Task<Product?> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product()
        {
            Name = request.ProductDto.Name,
            Category = request.ProductDto.Category,
            Description = request.ProductDto.Description,
            Image = request.ProductDto.Image,
            Price = request.ProductDto.Price
        };
        return await _repository.AddAsync(product) ?? null;
    }
}