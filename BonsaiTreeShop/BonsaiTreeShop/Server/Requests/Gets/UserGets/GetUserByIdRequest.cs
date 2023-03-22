namespace BonsaiTreeShop.Server.Requests.Gets.UserGets;

public record GetUserByIdRequest(string Id, HttpContext HttpContext): IHttpRequest;