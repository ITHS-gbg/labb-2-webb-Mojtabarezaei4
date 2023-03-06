using BonsaiTreeShop.DataAccess.Model;
using BonsaiTreeShop.DataAccess.Queries;
using BonsaiTreeShop.DataAccess.Repositories.Interfaces;
using MediatR;

namespace BonsaiTreeShop.DataAccess.Handlers;

public class GetAllProductHandler: IRequestHandler<GetAllProductQuery, IEnumerable<Product>>
{
    private readonly IRepository<Product> _repository;

    public GetAllProductHandler(IRepository<Product> repository)
    {
        _repository = repository;
    }
    public async Task<IEnumerable<Product>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
    { 
        return await _repository.GetAllAsync();
    }
}