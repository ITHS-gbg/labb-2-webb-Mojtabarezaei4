using BonsaiTreeShop.Server.Requests.Deletes.UserDelete;
using BonsaiTreeShop.Server.Requests.Gets.UserGets;

namespace BonsaiTreeShop.Server.Extensions.UserEndpoints;

public static class UserEndpoints
{
    public static void MapUserEndpoints(this WebApplication app)
    {
        app.MediateGet<GetAllUserRequest>("/users");
        app.MediateGet<GetUserByIdRequest>("/users/{id}");
        
        app.MediateDelete<DeleteUserByIdRequest>("/deleteUser/{id}");
    }
}