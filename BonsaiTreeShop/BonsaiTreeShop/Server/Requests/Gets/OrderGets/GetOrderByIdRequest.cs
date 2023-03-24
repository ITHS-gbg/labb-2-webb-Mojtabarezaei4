namespace BonsaiTreeShop.Server.Requests.Gets.OrderGets;

public record GetOrderByIdRequest(Guid Id) : IHttpRequest;