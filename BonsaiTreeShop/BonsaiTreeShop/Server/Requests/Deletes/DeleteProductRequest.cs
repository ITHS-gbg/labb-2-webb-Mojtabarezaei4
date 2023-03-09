namespace BonsaiTreeShop.Server.Requests.Deletes;

public record DeleteProductRequest(Guid Id) : IHttpRequest;