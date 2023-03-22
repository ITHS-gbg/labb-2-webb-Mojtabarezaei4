using BonsaiTreeShop.DataAccess.Commands.ProductCommands;
using BonsaiTreeShop.DataAccess.Repositories.Interfaces;
using BonsaiTreeShop.Shared;
using BonsaiTreeShop.Shared.DTOs;
using MediatR;

namespace BonsaiTreeShop.DataAccess.Handlers.Deletes.ProductDelete;

public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, ServiceResponse<ProductDto?>>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteProductHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ServiceResponse<ProductDto?>> Handle(DeleteProductCommand request,
        CancellationToken cancellationToken)
    {
        var product = await _unitOfWork.ProductRepository.DeleteByIdAsync(request.Id);
        if (product is null)
            return new ServiceResponse<ProductDto?>()
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