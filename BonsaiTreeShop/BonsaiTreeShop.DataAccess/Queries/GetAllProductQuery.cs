using BonsaiTreeShop.DataAccess.Model;
using MediatR;

namespace BonsaiTreeShop.DataAccess.Queries;

public record GetAllProductQuery(): IRequest<IEnumerable<Product>>;