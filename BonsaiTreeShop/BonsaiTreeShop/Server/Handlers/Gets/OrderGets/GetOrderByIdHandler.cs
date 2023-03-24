using System.Security.Claims;
using BonsaiTreeShop.DataAccess.Queries.OrderQueries;
using BonsaiTreeShop.Server.Requests.Gets.OrderGets;
using Duende.IdentityServer.Extensions;
using MediatR;

namespace BonsaiTreeShop.Server.Handlers.Gets.OrderGets;

public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdRequest, IResult>
{
    private readonly IMediator _mediator;

    public GetOrderByIdHandler(IMediator mediator)
    {
        _mediator = mediator;
    }
    public async Task<IResult> Handle(GetOrderByIdRequest request, CancellationToken cancellationToken)
    {

        var response = await _mediator.Send(new GetOrderByIdQuery(request.Id));

        //if (request.HttpContext.User.GetSubjectId() != response.Data.UserId) ;

        return response.Success ? Results.Ok(response) : Results.NotFound(response);
    }
}