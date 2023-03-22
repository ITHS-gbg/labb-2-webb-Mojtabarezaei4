namespace BonsaiTreeShop.Server.Requests.Deletes.UserDelete;

public record DeleteUserByIdRequest(string Id, HttpContext HttpContext): IHttpRequest;