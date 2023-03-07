using BonsaiTreeShop.DataAccess.Model;
using BonsaiTreeShop.Shared.DTOs;
using MediatR;

namespace BonsaiTreeShop.DataAccess.Queries;

public record GetAllProductQuery(): IRequest<IEnumerable<ProductDto>>;