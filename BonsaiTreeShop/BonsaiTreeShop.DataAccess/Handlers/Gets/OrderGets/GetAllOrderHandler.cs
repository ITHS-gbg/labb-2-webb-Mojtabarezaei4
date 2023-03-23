using BonsaiTreeShop.DataAccess.Queries.OrderQueries;
using BonsaiTreeShop.DataAccess.Repositories.Interfaces;
using BonsaiTreeShop.Shared;
using BonsaiTreeShop.Shared.DTOs;
using MediatR;

namespace BonsaiTreeShop.DataAccess.Handlers.Gets.OrderGets;

public class GetAllOrderHandler: IRequestHandler<GetAllOrderQuery, ServiceResponse<IEnumerable<OrderDto>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllOrderHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ServiceResponse<IEnumerable<OrderDto>>> Handle(GetAllOrderQuery request,
        CancellationToken cancellationToken)
    {
        return new ServiceResponse<IEnumerable<OrderDto>>()
        {
            Success = true,
            Data = await _unitOfWork.OrderRepository.GetAllAsync(),
            Message = "Succeed"
        };
    }
}