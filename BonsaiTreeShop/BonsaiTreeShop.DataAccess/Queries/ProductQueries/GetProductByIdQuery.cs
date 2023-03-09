using BonsaiTreeShop.Shared;
using BonsaiTreeShop.Shared.DTOs;
using MediatR;

namespace BonsaiTreeShop.DataAccess.Queries.ProductQueries;

public record GetProductByIdQuery(Guid Id) : IRequest<ServiceResponse<ProductDto?>>;