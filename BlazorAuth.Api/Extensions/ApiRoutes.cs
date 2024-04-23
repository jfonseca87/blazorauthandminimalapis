using BlazorAuth.Api.Handlers;

namespace BlazorAuth.Api.Extensions;

public static class ApiRoutes
{
    public static IEndpointRouteBuilder MapApiRoutes(this IEndpointRouteBuilder app)
    {
        app.MapGroup("/api/book").MapBookRoutes();
        app.MapGroup("/api/user").MapUserRoutes();

        return app;
    }
}