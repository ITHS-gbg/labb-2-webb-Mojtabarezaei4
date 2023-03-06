using BonsaiTreeShop.Server.Requests;

namespace BonsaiTreeShop.Server.Extensions;

public static class ProductEndpoints
{
    public static void MapProductEndpoints(this WebApplication app)
    {
        app.MediateGet<GetAllProductRequest>("products");
        
    }
}