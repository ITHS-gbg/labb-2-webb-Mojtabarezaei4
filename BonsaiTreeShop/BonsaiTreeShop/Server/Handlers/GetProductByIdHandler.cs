using BonsaiTreeShop.DataAccess.Queries;
using BonsaiTreeShop.Server.Requests;
using MediatR;

namespace BonsaiTreeShop.Server.Handlers;

public class GetProductByIdHandler : IRequestHandler<GetProductByIdRequest, IResult>
{
    private readonly IMediator _mediator;

    public GetProductByIdHandler(IMediator mediator)
    {
        _mediator = mediator;
    }
    public async Task<IResult> Handle(GetProductByIdRequest request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetProductByIdQuery(request.Id));

        return response.Success ? Results.Ok(response) : Results.NotFound(response);
    }
}