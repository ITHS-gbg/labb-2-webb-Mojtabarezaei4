using BonsaiTreeShop.Shared;
using BonsaiTreeShop.Shared.DTOs;
using MediatR;

namespace BonsaiTreeShop.DataAccess.Commands.ProductCommands;

public record AddProductCommand(ProductDto ProductDto) : IRequest<ServiceResponse<ProductDto?>>;