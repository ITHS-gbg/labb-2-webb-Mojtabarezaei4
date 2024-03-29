﻿using BonsaiTreeShop.DataAccess.Queries.ProductQueries;
using BonsaiTreeShop.Server.Requests.Gets.ProductGets;
using MediatR;

namespace BonsaiTreeShop.Server.Handlers.Gets.ProductGets;

public class GetAllProductHandler : IRequestHandler<GetAllProductRequest, IResult>
{
    private readonly IMediator _mediator;

    public GetAllProductHandler(IMediator mediator)
    {
        _mediator = mediator;
    }
    public async Task<IResult> Handle(GetAllProductRequest request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllProductQuery());

        return response.Success ? Results.Ok(response) : Results.NoContent();
    }
}