using BonsaiTreeShop.DataAccess.Commands.UserCommands;
using BonsaiTreeShop.DataAccess.Repositories.Interfaces;
using BonsaiTreeShop.Shared;
using BonsaiTreeShop.Shared.DTOs;
using MediatR;

namespace BonsaiTreeShop.DataAccess.Handlers.Puts;

public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, ServiceResponse<UserDto?>>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateUserHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ServiceResponse<UserDto?>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.UserRepository.UpdateAsync(request.UserDto, request.Id);

        if (user is null)
            return new ServiceResponse<UserDto?>()
            {
                Success = false,
                Data = null,
                Message = "Something went wrong!"
            };

        await _unitOfWork.CompleteAsync();
        return new ServiceResponse<UserDto?>()
        {
            Success = true,
            Data = user,
            Message = "Succeed"
        };
    }
}