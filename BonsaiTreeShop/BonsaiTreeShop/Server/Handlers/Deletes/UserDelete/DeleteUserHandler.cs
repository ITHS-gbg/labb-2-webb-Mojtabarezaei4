using BonsaiTreeShop.DataAccess.Commands.UserCommands;
using BonsaiTreeShop.Server.Requests.Deletes.UserDelete;
using MediatR;

namespace BonsaiTreeShop.Server.Handlers.Deletes.UserDelete;

public class DeleteUserHandler : IRequestHandler<DeleteUserByIdRequest, IResult>
{
    private readonly IMediator _mediator;

    public DeleteUserHandler(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IResult> Handle(DeleteUserByIdRequest request, CancellationToken cancellationToken)
    {
        if (!request.HttpContext.User.IsInRole("Admin")) return Results.Unauthorized();

        var response = await _mediator.Send(new DeleteUserCommand(request.Id));

        return response.Success ? Results.Ok(response) : Results.NotFound(response);
    }
}