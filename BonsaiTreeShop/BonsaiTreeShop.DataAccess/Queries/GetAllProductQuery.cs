using BonsaiTreeShop.Shared;
using BonsaiTreeShop.Shared.DTOs;
using MediatR;

namespace BonsaiTreeShop.DataAccess.Queries;

public record GetAllProductQuery(): IRequest<ServiceResponse<IEnumerable<ProductDto>>>;