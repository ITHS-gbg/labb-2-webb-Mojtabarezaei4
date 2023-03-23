using BonsaiTreeShop.DataAccess.Queries.OrderQueries;
using BonsaiTreeShop.DataAccess.Repositories.Interfaces;
using BonsaiTreeShop.Shared;
using BonsaiTreeShop.Shared.DTOs;
using MediatR;

namespace BonsaiTreeShop.DataAccess.Handlers.Gets.OrderGets;

public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdQuery, ServiceResponse<OrderDto?>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetOrderByIdHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ServiceResponse<OrderDto?>> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var order = await _unitOfWork.OrderRepository.GetByIdAsync(request.Id);
        return order is not null ? new ServiceResponse<OrderDto?>()
        {
            Success = true,
            Data = order,
            Message = "Succeed"
        } : new ServiceResponse<OrderDto?>()
        {
            Success = false,
            Data = null,
            Message = "Couldn't find"
        };
    }
}