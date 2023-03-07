using BonsaiTreeShop.DataAccess.Model;
using BonsaiTreeShop.DataAccess.Repositories.Interfaces;
using BonsaiTreeShop.Server.Requests;
using BonsaiTreeShop.Shared.DTOs;
using MediatR;

namespace BonsaiTreeShop.Server.Extensions;

public static class WebApplicationEndPointExtensions
{
    public static WebApplication MediateGet<TRequest>(this WebApplication app, string template) where TRequest : IHttpRequest
    {
        app.MapGet(template,
            async (IMediator mediator, [AsParameters] TRequest request)
                => await mediator.Send(request));

        return app;
    }

    public static WebApplication MediatePost<TRequest>(this WebApplication app, string template) where TRequest : IHttpRequest
    {
        app.MapPost(template,
            async (IMediator mediator, [AsParameters] TRequest request)
                => await mediator.Send(request));

        return app;
    }
}