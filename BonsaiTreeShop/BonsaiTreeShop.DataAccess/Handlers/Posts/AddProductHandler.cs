using BonsaiTreeShop.DataAccess.Commands.ProductCommands;
using BonsaiTreeShop.DataAccess.Repositories.Interfaces;
using BonsaiTreeShop.Shared;
using BonsaiTreeShop.Shared.DTOs;
using MediatR;

namespace BonsaiTreeShop.DataAccess.Handlers.Posts;

public class AddProductHandler : IRequestHandler<AddProductCommand, ServiceResponse<ProductDto?>>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddProductHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ServiceResponse<ProductDto?>> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        var product = new ProductDto(
            Name: request.ProductDto.Name,
            Description: request.ProductDto.Description,
            Price: request.ProductDto.Price,
            Image: request.ProductDto.Image,
            Category: request.ProductDto.Category
        );

        if (product is null) return new ServiceResponse<ProductDto?>()
        {
            Success = false,
            Data = null,
            Message = "Succeed"
        };

        await _unitOfWork.ProductRepository.AddAsync(product);
        await _unitOfWork.CompleteAsync();
        return new ServiceResponse<ProductDto?>()
        {
            Success = true,
            Data = product,
            Message = "Succeed"
        };
    }
}