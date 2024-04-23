using BlazorAuth.Api.Repositories;
using BlazorAuth.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlazorAuth.Api.Handlers;

public static class UserHandlers
{
    public static IEndpointRouteBuilder MapUserRoutes(this IEndpointRouteBuilder app)
    {
        app.MapGet("/", GetUsers).RequireAuthorization("RequireAdminRole").WithName("GetUsers");
        app.MapPost("/login", Login).WithName("Login");

        return app;
    }

    public static IResult Login([FromServices] IUserRepository userRepository, [FromBody] Login login)
    {
        var result = userRepository.Login(login);
        if (!result.Success) return Results.Unauthorized();

        return Results.Ok(new ResponseModelData<LoginResponse>
        {
            Data = result,
            Success = true
        });
    }

    public static IResult GetUsers([FromServices] IUserRepository userRepository, HttpContext httpContext)
    {
        var result = userRepository.GetUsers();
        return Results.Ok(new ResponseModelData<IEnumerable<User>>
        {
            Data = result,
            Success = true
        });
    }
}