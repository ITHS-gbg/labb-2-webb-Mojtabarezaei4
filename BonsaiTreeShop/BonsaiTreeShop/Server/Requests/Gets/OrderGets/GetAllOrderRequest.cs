namespace BonsaiTreeShop.Server.Requests.Gets.OrderGets;

public record GetAllOrderRequest(Guid? UserId, HttpContext HttpContext) : IHttpRequest;