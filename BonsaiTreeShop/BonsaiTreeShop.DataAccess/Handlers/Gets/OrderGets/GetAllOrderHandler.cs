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
        var orders = await _unitOfWork.OrderRepository.GetAllAsync();

        return new ServiceResponse<IEnumerable<OrderDto>>()
        {
            Success = true,
            Data = orders.Where(o => o.UserId == request.UserId),
            Message = "Succeed"
        };
    }
}