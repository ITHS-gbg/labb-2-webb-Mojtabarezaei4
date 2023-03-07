using BonsaiTreeShop.DataAccess.Queries;
using BonsaiTreeShop.Server.Requests;
using BonsaiTreeShop.Shared;
using BonsaiTreeShop.Shared.DTOs;
using Duende.IdentityServer.Models;
using MediatR;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BonsaiTreeShop.Server.Handlers;

public class GetAllProductHandler: IRequestHandler<GetAllProductRequest, IResult>
{
    private readonly IMediator _mediator;
    //private readonly IResponseService<ProductDto> _responseService;

    public GetAllProductHandler(IMediator mediator)
    {
        _mediator = mediator;
        //_responseService = responseService;
    }
    public async Task<IResult> Handle(GetAllProductRequest request, CancellationToken cancellationToken)
    {
        var response = new ServiceResponse<IEnumerable<ProductDto>>()
        {
            Success = true,
            Data = await _mediator.Send(new GetAllProductQuery()),
            Message = "Succeed"
        };
        return Results.Ok(response);
    }
}