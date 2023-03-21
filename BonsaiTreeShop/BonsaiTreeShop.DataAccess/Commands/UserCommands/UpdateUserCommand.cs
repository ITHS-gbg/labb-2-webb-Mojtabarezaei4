using BonsaiTreeShop.Shared.DTOs;
using BonsaiTreeShop.Shared;
using MediatR;

namespace BonsaiTreeShop.DataAccess.Commands.UserCommands;

public record UpdateUserCommand(UserDto UserDto, string Id) : IRequest<ServiceResponse<UserDto?>>;