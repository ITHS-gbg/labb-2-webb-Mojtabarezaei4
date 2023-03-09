namespace BonsaiTreeShop.Server.Requests;

public record DeleteProductRequest(Guid Id) : IHttpRequest;