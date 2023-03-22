using BonsaiTreeShop.Shared;
using BonsaiTreeShop.Shared.DTOs;
using MediatR;

namespace BonsaiTreeShop.DataAccess.Commands.UserCommands;

public record DeleteUserCommand(string Id): IRequest<ServiceResponse<UserDto?>>;