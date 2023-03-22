namespace BonsaiTreeShop.Server.Requests.Gets.ProductGets;

public record GetProductByIdRequest(Guid Id) : IHttpRequest;