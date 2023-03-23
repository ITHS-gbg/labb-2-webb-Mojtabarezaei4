using BonsaiTreeShop.Shared;
using BonsaiTreeShop.Shared.DTOs;
using MediatR;

namespace BonsaiTreeShop.DataAccess.Queries.OrderQueries;

public record GetOrderByIdQuery(Guid Id) : IRequest<ServiceResponse<OrderDto?>>;