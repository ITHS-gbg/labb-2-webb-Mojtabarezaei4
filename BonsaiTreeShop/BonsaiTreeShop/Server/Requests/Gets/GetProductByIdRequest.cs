namespace BonsaiTreeShop.Server.Requests.Gets;

public record GetProductByIdRequest(Guid Id) : IHttpRequest;