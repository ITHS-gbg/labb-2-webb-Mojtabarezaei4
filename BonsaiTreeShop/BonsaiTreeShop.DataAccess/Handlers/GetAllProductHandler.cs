using BonsaiTreeShop.DataAccess.Model;
using BonsaiTreeShop.DataAccess.Queries;
using BonsaiTreeShop.DataAccess.Repositories.Interfaces;
using BonsaiTreeShop.Shared.DTOs;
using MediatR;

namespace BonsaiTreeShop.DataAccess.Handlers;

public class GetAllProductHandler: IRequestHandler<GetAllProductQuery, IEnumerable<ProductDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllProductHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<IEnumerable<ProductDto>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
    { 
        return await _unitOfWork.ProductRepository.GetAllAsync();
    }
}