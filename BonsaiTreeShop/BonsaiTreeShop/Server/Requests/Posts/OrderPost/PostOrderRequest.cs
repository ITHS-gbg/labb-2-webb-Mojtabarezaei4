using BonsaiTreeShop.Shared.DTOs;

namespace BonsaiTreeShop.Server.Requests.Posts.OrderPost;

public record PostOrderRequest(OrderDto OrderDto, HttpContext HttpContext) : IHttpRequest;