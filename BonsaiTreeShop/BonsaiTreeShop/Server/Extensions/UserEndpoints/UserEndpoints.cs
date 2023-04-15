using BonsaiTreeShop.Server.Requests.Deletes.UserDelete;
using BonsaiTreeShop.Server.Requests.Gets.UserGets;

namespace BonsaiTreeShop.Server.Extensions.UserEndpoints;

public static class UserEndpoints
{
    public static void MapUserEndpoints(this WebApplication app)
    {
        app.MediateGet<GetAllUserRequest>("/api/users");
        app.MediateGet<GetUserByIdRequest>("/api/users/{id}");
        
        app.MediateDelete<DeleteUserByIdRequest>("/api/deleteUser/{id}");
    }
}