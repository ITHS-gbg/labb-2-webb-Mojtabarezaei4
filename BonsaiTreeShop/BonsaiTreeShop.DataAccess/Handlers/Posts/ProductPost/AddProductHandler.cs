using BonsaiTreeShop.DataAccess.Commands.ProductCommands;
using BonsaiTreeShop.DataAccess.Repositories.Interfaces;
using BonsaiTreeShop.Shared;
using BonsaiTreeShop.Shared.DTOs;
using MediatR;

namespace BonsaiTreeShop.DataAccess.Handlers.Posts.ProductPost;

public class AddProductHandler : IRequestHandler<AddProductCommand, ServiceResponse<ProductDto?>>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddProductHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ServiceResponse<ProductDto?>> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _unitOfWork.ProductRepository.AddAsync(request.ProductDto);

        if (product is null) return new ServiceResponse<ProductDto?>()
        {
            Success = false,
            Data = null,
            Message = "Something went wrong!"
        };

        await _unitOfWork.CompleteAsync();

        return new ServiceResponse<ProductDto?>()
        {
            Success = true,
            Data = product,
            Message = "Succeed"
        };
    }
}