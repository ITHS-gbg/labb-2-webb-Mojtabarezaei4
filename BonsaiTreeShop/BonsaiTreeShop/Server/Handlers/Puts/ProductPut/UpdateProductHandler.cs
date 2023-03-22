using BonsaiTreeShop.DataAccess.Commands.ProductCommands;
using BonsaiTreeShop.Server.Requests.Puts.ProductPut;
using MediatR;

namespace BonsaiTreeShop.Server.Handlers.Puts.ProductPut;

public class UpdateProductHandler : IRequestHandler<UpdateProductRequest, IResult>
{
    private readonly IMediator _mediator;

    public UpdateProductHandler(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IResult> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
    {
        if (!request.HttpContext.User.IsInRole("Admin")) return Results.Unauthorized();

        var response = await _mediator.Send(new UpdateProductCommand(request.ProductDto, request.Id));

        return response.Success ? Results.Ok(response) : Results.BadRequest(response);
    }
}