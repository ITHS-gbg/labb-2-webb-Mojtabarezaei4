using BonsaiTreeShop.Server.Requests.Deletes.ProductDelete;
using BonsaiTreeShop.Server.Requests.Gets.OrderGets;
using BonsaiTreeShop.Server.Requests.Gets.ProductGets;
using BonsaiTreeShop.Server.Requests.Posts.OrderPost;
using BonsaiTreeShop.Server.Requests.Posts.ProductPost;
using BonsaiTreeShop.Server.Requests.Puts.ProductPut;

namespace BonsaiTreeShop.Server.Extensions.OrderEndpoints;

public static class OrderEndpoints
{
    public static void MapOrderEndpoints(this WebApplication app)
    {
        app.MediateGet<GetAllOrderRequest>("/api/orders");
        app.MediateGet<GetOrderByIdRequest>("/api/orders/{id}");

        app.MediatePost<PostOrderRequest>("/api/addOrder");
    }
}