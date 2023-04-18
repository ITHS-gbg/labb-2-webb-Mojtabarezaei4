using System.Security.Claims;
using BonsaiTreeShop.DataAccess.Queries.OrderQueries;
using BonsaiTreeShop.Server.Requests.Gets.OrderGets;
using MediatR;

namespace BonsaiTreeShop.Server.Handlers.Gets.OrderGets;

public class GetAllOrderHandler : IRequestHandler<GetAllOrderRequest, IResult>
{
    private readonly IMediator _mediator;

    public GetAllOrderHandler(IMediator mediator)
    {
        _mediator = mediator;
    }
    public async Task<IResult> Handle(GetAllOrderRequest request, CancellationToken cancellationToken)
    {
        var userId = request.UserId.ToString();

        if (string.IsNullOrEmpty(request.UserId.ToString()))
        {
            userId = request.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        }
        
        var response = await _mediator.Send(new GetAllOrderQuery(userId!));

        return response.Success ? Results.Ok(response) : Results.NoContent();

    }
}