using BonsaiTreeShop.DataAccess.Queries.UserQueries;
using BonsaiTreeShop.DataAccess.Repositories.Interfaces;
using BonsaiTreeShop.Shared.DTOs;
using BonsaiTreeShop.Shared;
using MediatR;

namespace BonsaiTreeShop.DataAccess.Handlers.Gets.UserGets;

public class GetAllUserHandler : IRequestHandler<GetAllUserQuery, ServiceResponse<IEnumerable<UserDto>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllUserHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<ServiceResponse<IEnumerable<UserDto>>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
    {
        return new ServiceResponse<IEnumerable<UserDto>>
        {
            Success = true,
            Data = await _unitOfWork.UserRepository.GetAllAsync(),
            Message = "Succeed"
        };
    }
}