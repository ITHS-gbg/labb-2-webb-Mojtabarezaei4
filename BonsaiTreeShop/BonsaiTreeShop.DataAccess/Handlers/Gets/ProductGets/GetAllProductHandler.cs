using BonsaiTreeShop.DataAccess.Queries.ProductQueries;
using BonsaiTreeShop.DataAccess.Repositories.Interfaces;
using BonsaiTreeShop.Shared;
using BonsaiTreeShop.Shared.DTOs;
using MediatR;

namespace BonsaiTreeShop.DataAccess.Handlers.Gets.ProductGets;

public class GetAllProductHandler : IRequestHandler<GetAllProductQuery, ServiceResponse<IEnumerable<ProductDto>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllProductHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<ServiceResponse<IEnumerable<ProductDto>>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
    {
        return new ServiceResponse<IEnumerable<ProductDto>>
        {
            Success = true,
            Data = await _unitOfWork.ProductRepository.GetAllAsync(),
            Message = "Succeed"
        };
    }
}