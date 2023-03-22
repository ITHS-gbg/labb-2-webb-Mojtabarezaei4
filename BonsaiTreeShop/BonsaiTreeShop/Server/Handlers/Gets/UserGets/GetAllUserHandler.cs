using BonsaiTreeShop.DataAccess.Queries.UserQueries;
using BonsaiTreeShop.Server.Requests.Gets.UserGets;
using MediatR;

namespace BonsaiTreeShop.Server.Handlers.Gets.UserGets;

public class GetAllUserHandler : IRequestHandler<GetAllUserRequest, IResult>
{
    private readonly IMediator _mediator;

    public GetAllUserHandler(IMediator mediator)
    {
        _mediator = mediator;
    }
    public async Task<IResult> Handle(GetAllUserRequest request, CancellationToken cancellationToken)
    {
        if (!request.HttpContext.User.IsInRole("Admin")) return Results.Unauthorized();

        var response = await _mediator.Send(new GetAllUserQuery());

        return response.Success ? Results.Ok(response) : Results.NoContent();
    }

}