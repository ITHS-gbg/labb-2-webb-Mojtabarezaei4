using BonsaiTreeShop.DataAccess.Commands;
using BonsaiTreeShop.Server.Requests;
using MediatR;

namespace BonsaiTreeShop.Server.Handlers;

public class AddProductHandler: IRequestHandler<AddProductRequest, IResult>
{
    private readonly IMediator _mediator;

    public AddProductHandler(IMediator mediator)
    {
        _mediator = mediator;
    }
    public async Task<IResult> Handle(AddProductRequest request, CancellationToken cancellationToken)
    {
        var product = request.ProductDto;
        var response = await _mediator.Send(new AddProductCommand(product));

        return response.Success ? Results.Ok(response) : Results.BadRequest(response);
    }
}