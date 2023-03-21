namespace BonsaiTreeShop.Server.Requests.Deletes;

public record DeleteProductRequest(Guid Id, HttpContext HttpContext) : IHttpRequest;