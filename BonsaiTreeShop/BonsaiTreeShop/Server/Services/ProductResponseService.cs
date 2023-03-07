using BonsaiTreeShop.DataAccess.Queries;
using BonsaiTreeShop.Shared;
using BonsaiTreeShop.Shared.DTOs;
using MediatR;

namespace BonsaiTreeShop.Server.Services;

public class ProductResponseService : IResponseService<ProductDto>
{
    private readonly IMediator _mediator;

    public ProductResponseService(IMediator mediator)
    {
        _mediator = mediator;
    }
    public async Task<ServiceResponse<IEnumerable<ProductDto>>> GetAll()
    {
        return new ServiceResponse<IEnumerable<ProductDto>>()
        {
            Success = true,
            Data = await _mediator.Send(new GetAllProductQuery()),
            Message = "Succeed"
        };
    }

    public async Task<ServiceResponse<ProductDto?>> GetOne(object id)
    {
        throw new NotImplementedException();
    }

    public async Task<ServiceResponse<ProductDto?>> Add(ProductDto newDto)
    {
        throw new NotImplementedException();
    }

    public async Task<ServiceResponse<ProductDto?>> UpdateOne(ProductDto newDto)
    {
        throw new NotImplementedException();
    }

    public async Task<ServiceResponse<ProductDto?>> Delete(object id)
    {
        throw new NotImplementedException();
    }
}