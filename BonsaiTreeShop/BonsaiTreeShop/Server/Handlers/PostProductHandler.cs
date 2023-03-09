using BonsaiTreeShop.DataAccess.Commands;
using BonsaiTreeShop.Server.Requests;
using MediatR;

namespace BonsaiTreeShop.Server.Handlers;

public class PostProductHandler: IRequestHandler<PostProductRequest, IResult>
{
    private readonly IMediator _mediator;

    public PostProductHandler(IMediator mediator)
    {
        _mediator = mediator;
    }
    public async Task<IResult> Handle(PostProductRequest request, CancellationToken cancellationToken)
    {
        var product = request.ProductDto;
        var response = await _mediator.Send(new AddProductCommand(product));

        return response.Success ? Results.Ok(response) : Results.BadRequest(response);
    }
}