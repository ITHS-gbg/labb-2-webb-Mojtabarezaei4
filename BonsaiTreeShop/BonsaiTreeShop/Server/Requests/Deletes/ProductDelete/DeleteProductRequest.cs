namespace BonsaiTreeShop.Server.Requests.Deletes.ProductDelete;

public record DeleteProductRequest(Guid Id, HttpContext HttpContext) : IHttpRequest;