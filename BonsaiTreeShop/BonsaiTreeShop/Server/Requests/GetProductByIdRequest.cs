namespace BonsaiTreeShop.Server.Requests;

public record GetProductByIdRequest (Guid Id) : IHttpRequest;