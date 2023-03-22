using BonsaiTreeShop.DataAccess.Queries.ProductQueries;
using BonsaiTreeShop.DataAccess.Repositories.Interfaces;
using BonsaiTreeShop.Shared;
using BonsaiTreeShop.Shared.DTOs;
using MediatR;

namespace BonsaiTreeShop.DataAccess.Handlers.Gets.ProductGets;

public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ServiceResponse<ProductDto?>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetProductByIdHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ServiceResponse<ProductDto?>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _unitOfWork.ProductRepository.GetByIdAsync(request.Id);
        return product is not null
            ? new ServiceResponse<ProductDto?>()
            {
                Success = true,
                Data = product,
                Message = "Succeed"
            }
            : new ServiceResponse<ProductDto?>()
            {
                Success = false,
                Data = product,
                Message = "Couldn't find!"
            };
    }
}