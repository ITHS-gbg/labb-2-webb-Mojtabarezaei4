using BonsaiTreeShop.Shared;
using BonsaiTreeShop.Shared.DTOs;
using MediatR;

namespace BonsaiTreeShop.DataAccess.Queries.ProductQueries;

public record GetAllProductQuery() : IRequest<ServiceResponse<IEnumerable<ProductDto>>>;