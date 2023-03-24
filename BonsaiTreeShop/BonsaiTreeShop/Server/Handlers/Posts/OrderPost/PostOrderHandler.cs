using System.Security.Claims;
using BonsaiTreeShop.DataAccess.Commands.OrderCommands;
using BonsaiTreeShop.DataAccess.Queries.ProductQueries;
using BonsaiTreeShop.Server.Requests.Posts.OrderPost;
using BonsaiTreeShop.Shared;
using BonsaiTreeShop.Shared.DTOs;
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

        var userId = request.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        if (userId is null) return Results.Forbid();

        var orderDetails = new List<OrderDetailsDto>();

        foreach (var orderDetailDto in request.OrderDto.OrderDetails)
        {
            var product = await _mediator.Send(
            new GetProductByIdQuery(orderDetailDto.ProductId));

            orderDetails.Add( new OrderDetailsDto(product.Data!.Id, orderDetailDto.Quantity));
        }

        var orderDto = new OrderDto(request.OrderDto.ShipAddress, DateTime.UtcNow, orderDetails, userId);

        var response = await _mediator.Send(new AddOrderCommand(new OrderDto(request.OrderDto.ShipAddress, DateTime.UtcNow, orderDetails, userId)));
        return response.Success ? Results.Ok(response) : Results.BadRequest(response);
    }
}