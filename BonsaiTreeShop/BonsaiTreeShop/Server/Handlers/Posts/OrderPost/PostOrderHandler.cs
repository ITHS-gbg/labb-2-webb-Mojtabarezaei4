using System.Security.Claims;
using BonsaiTreeShop.DataAccess.Commands.OrderCommands;
using BonsaiTreeShop.Server.Requests.Posts.OrderPost;
using BonsaiTreeShop.Shared;
using MediatR;

namespace BonsaiTreeShop.Server.Handlers.Posts.OrderPost;

public class PostOrderHandler : IRequestHandler<PostOrderRequest, IResult>
{
    private readonly IMediator _mediator;

    public PostOrderHandler(IMediator mediator)
    {
        _mediator = mediator;
    }
    public async Task<IResult> Handle(PostOrderRequest request, CancellationToken cancellationToken)
    {
        var orderDto = request.OrderDto;

        var userId = request.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        if (userId is null) return Results.Forbid();

        //orderDto.UserId = userId;

        var response = await _mediator.Send(new AddOrderCommand(orderDto));

        return response.Success ? Results.Ok(response) : Results.BadRequest(response);
    }
}