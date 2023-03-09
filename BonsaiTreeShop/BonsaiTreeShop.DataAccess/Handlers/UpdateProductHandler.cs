using BonsaiTreeShop.DataAccess.Commands;
using BonsaiTreeShop.DataAccess.Repositories.Interfaces;
using BonsaiTreeShop.Shared;
using BonsaiTreeShop.Shared.DTOs;
using MediatR;

namespace BonsaiTreeShop.DataAccess.Handlers;

public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, ServiceResponse<ProductDto?>>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateProductHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ServiceResponse<ProductDto?>> Handle(UpdateProductCommand request,
        CancellationToken cancellationToken)
    {
        var product = await _unitOfWork.ProductRepository.UpdateAsync(request.ProductDto, request.Id);


        if (product is null)
            return new ServiceResponse<ProductDto?>()
            {
                Success = false,
                Data = null,
                Message = "Didn't find the product!"
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