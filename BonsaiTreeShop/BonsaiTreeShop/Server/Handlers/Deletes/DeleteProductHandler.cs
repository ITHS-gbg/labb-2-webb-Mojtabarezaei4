using BonsaiTreeShop.DataAccess.Commands.ProductCommands;
using BonsaiTreeShop.Server.Requests.Deletes;
using MediatR;

namespace BonsaiTreeShop.Server.Handlers.Deletes;

public class DeleteProductHandler : IRequestHandler<DeleteProductRequest, IResult>
{
    private readonly IMediator _mediator;

    public DeleteProductHandler(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IResult> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new DeleteProductCommand(request.Id));

        return response.Success ? Results.Ok(response) : Results.NotFound(response);
    }
}