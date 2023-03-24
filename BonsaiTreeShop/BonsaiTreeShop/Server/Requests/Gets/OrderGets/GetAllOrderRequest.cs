namespace BonsaiTreeShop.Server.Requests.Gets.OrderGets;

public record GetAllOrderRequest(HttpContext HttpContext) : IHttpRequest;