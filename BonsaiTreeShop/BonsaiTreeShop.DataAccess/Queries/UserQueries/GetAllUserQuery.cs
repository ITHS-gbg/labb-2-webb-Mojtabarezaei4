using BonsaiTreeShop.Shared;
using BonsaiTreeShop.Shared.DTOs;
using MediatR;

namespace BonsaiTreeShop.DataAccess.Queries.UserQueries;

public record GetAllUserQuery() : IRequest<ServiceResponse<IEnumerable<UserDto>>>;