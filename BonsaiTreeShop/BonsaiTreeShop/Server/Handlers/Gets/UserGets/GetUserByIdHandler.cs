using System.Security.Claims;
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
        var userId = request.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

        if ((userId!.Equals(request.Id)))
        {
            var response = await _mediator.Send(new GetUserByIdQuery(request.Id));

            return response.Success ? Results.Ok(response) : Results.NotFound(response);
        }

        if (request.HttpContext.User.IsInRole("Admin"))
        {
            var response = await _mediator.Send(new GetUserByIdQuery(request.Id));

            return response.Success ? Results.Ok(response) : Results.NotFound(response);
        }
        if (!Guid.TryParse(request.Id, out _))
        {
            var user = await _mediator.Send(new GetUserByIdQuery(request.Id));
            return user.Success && user.Data!.Email.Equals(request.Id) ? Results.Ok(user) : Results.NotFound(user);
        }
        
        return Results.Unauthorized();
    }
}