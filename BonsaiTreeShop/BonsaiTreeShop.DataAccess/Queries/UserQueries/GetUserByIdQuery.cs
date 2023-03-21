using BonsaiTreeShop.Shared;
using BonsaiTreeShop.Shared.DTOs;
using MediatR;

namespace BonsaiTreeShop.DataAccess.Queries.UserQueries;

public record GetUserByIdQuery(string Id): IRequest<ServiceResponse<UserDto?>>;