using BonsaiTreeShop.DataAccess.Commands;
using BonsaiTreeShop.DataAccess.Model;
using BonsaiTreeShop.Server.Requests;
using BonsaiTreeShop.Shared.DTOs;
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
        return Results.Ok(await _mediator.Send(new AddProductCommand(product)));
    }
}