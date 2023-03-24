using BonsaiTreeShop.DataAccess.Commands.OrderCommands;
using BonsaiTreeShop.DataAccess.Repositories.Interfaces;
using BonsaiTreeShop.Shared;
using BonsaiTreeShop.Shared.DTOs;
using MediatR;

namespace BonsaiTreeShop.DataAccess.Handlers.Posts.OrderPost;

public class AddOrderHandler : IRequestHandler<AddOrderCommand, ServiceResponse<OrderDto?>>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddOrderHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ServiceResponse<OrderDto?>> Handle(AddOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _unitOfWork.OrderRepository.AddAsync(request.OrderDto);

        if (order is null)
        {
            return new ServiceResponse<OrderDto?>()
            {
                Success = false,
                Data = order,
                Message = "Something went wrong!"
            };
        }
        
        await _unitOfWork.CompleteAsync();

        return new ServiceResponse<OrderDto?>()
        {
            Success = true,
            Data = order,
            Message = "Succeed"
        };
    }
}