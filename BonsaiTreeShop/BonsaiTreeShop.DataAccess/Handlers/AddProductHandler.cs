using BonsaiTreeShop.DataAccess.Commands;
using BonsaiTreeShop.DataAccess.Model;
using BonsaiTreeShop.DataAccess.Repositories;
using BonsaiTreeShop.DataAccess.Repositories.Interfaces;
using MediatR;

namespace BonsaiTreeShop.DataAccess.Handlers;

public class AddProductHandler: IRequestHandler<AddProductCommand, Product>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddProductHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
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
        if (product is null)
        {
            return null;
        }

        await _unitOfWork.ProductRepository.AddAsync(product);
        await _unitOfWork.CompleteAsync();
        return product;
    }
}