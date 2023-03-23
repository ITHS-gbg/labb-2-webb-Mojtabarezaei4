using BonsaiTreeShop.Shared;
using BonsaiTreeShop.Shared.DTOs;
using MediatR;

namespace BonsaiTreeShop.DataAccess.Commands.OrderCommands;

public record AddOrderCommand(OrderDto OrderDto): IRequest<ServiceResponse<OrderDto?>>;