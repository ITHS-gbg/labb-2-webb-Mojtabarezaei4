using BonsaiTreeShop.DataAccess.Queries.UserQueries;
using BonsaiTreeShop.Server.Requests.Gets.UserGets;
using MediatR;

namespace BonsaiTreeShop.Server.Handlers.Gets.UserGets;

public class GetUserByIdHandler : IRequestHandler<GetUserByIdRequest, IResult>
{
    private readonly IMediator _mediator;

    public GetUserByIdHandler(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IResult> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
    {
        if (!request.HttpContext.User.IsInRole("Admin")) return Results.Unauthorized();

        var response = await _mediator.Send(new GetUserByIdQuery(request.Id));

        return response.Success ? Results.Ok(response) : Results.NotFound(response);
    }
}