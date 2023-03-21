using BonsaiTreeShop.DataAccess.Queries.UserQueries;
using BonsaiTreeShop.DataAccess.Repositories.Interfaces;
using BonsaiTreeShop.Shared;
using BonsaiTreeShop.Shared.DTOs;
using MediatR;

namespace BonsaiTreeShop.DataAccess.Handlers.Gets;

public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, ServiceResponse<UserDto?>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetUserByIdHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ServiceResponse<UserDto?>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.UserRepository.GetByIdAsync(request.Id);
        return user is not null
            ? new ServiceResponse<UserDto?>()
            {
                Success = true,
                Data = user,
                Message = "Succeed"
            }
            : new ServiceResponse<UserDto?>()
            {
                Success = false,
                Data = user,
                Message = "Couldn't find!"
            };
    }
}