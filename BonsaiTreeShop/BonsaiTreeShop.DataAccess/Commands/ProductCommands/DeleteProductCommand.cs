using BonsaiTreeShop.Shared;
using BonsaiTreeShop.Shared.DTOs;
using MediatR;

namespace BonsaiTreeShop.DataAccess.Commands.ProductCommands;

public record DeleteProductCommand(Guid Id) : IRequest<ServiceResponse<ProductDto?>>;