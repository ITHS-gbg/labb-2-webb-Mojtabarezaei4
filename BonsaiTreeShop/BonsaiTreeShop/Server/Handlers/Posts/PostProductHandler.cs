using BonsaiTreeShop.DataAccess.Commands.ProductCommands;
using BonsaiTreeShop.Server.Requests.Posts;
using MediatR;

namespace BonsaiTreeShop.Server.Handlers.Posts;

public class PostProductHandler : IRequestHandler<PostProductRequest, IResult>
{
    private readonly IMediator _mediator;

    public PostProductHandler(IMediator mediator)
    {
        _mediator = mediator;
    }
    public async Task<IResult> Handle(PostProductRequest request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new AddProductCommand(request.ProductDto));

        return response.Success ? Results.Ok(response) : Results.BadRequest(response);
    }
}