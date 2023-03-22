using BonsaiTreeShop.DataAccess.Commands.UserCommands;
using BonsaiTreeShop.DataAccess.Repositories.Interfaces;
using BonsaiTreeShop.Shared;
using BonsaiTreeShop.Shared.DTOs;
using MediatR;

namespace BonsaiTreeShop.DataAccess.Handlers.Deletes.UserDelete;

public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, ServiceResponse<UserDto?>>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteUserHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<ServiceResponse<UserDto?>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.UserRepository.DeleteByIdAsync(request.Id);
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