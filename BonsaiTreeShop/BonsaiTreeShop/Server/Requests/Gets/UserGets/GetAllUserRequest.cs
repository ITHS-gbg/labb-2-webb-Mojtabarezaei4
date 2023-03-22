namespace BonsaiTreeShop.Server.Requests.Gets.UserGets;

public record GetAllUserRequest(HttpContext HttpContext) : IHttpRequest;