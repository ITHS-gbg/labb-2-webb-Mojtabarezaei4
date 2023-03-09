using BonsaiTreeShop.DataAccess.Commands.ProductCommands;
using BonsaiTreeShop.Server.Requests.Puts;
using MediatR;

namespace BonsaiTreeShop.Server.Handlers.Puts;

public class UpdateProductHandler : IRequestHandler<UpdateProductRequest, IResult>
{
    private readonly IMediator _mediator;

    public UpdateProductHandler(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IResult> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new UpdateProductCommand(request.ProductDto, request.Id));

        return response.Success ? Results.Ok(response) : Results.BadRequest(response);
    }
}