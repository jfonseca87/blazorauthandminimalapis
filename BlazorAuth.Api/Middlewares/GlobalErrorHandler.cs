using System.Net;
using System.Text.Json;
using BlazorAuth.Shared.Models;

namespace BlazorAuth.Api.Middlewares;

public class GlobalErrorHandler(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            await HandleExceptionAsync(context);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context)
    {
        var statusCode = HttpStatusCode.InternalServerError;
        var errorMessage = "An unexpected error occurred.";

        context.Response.StatusCode = (int)statusCode;
        context.Response.ContentType = "application/json";

        var responseModel = new ResponseModel
        {
            Success = false,
            Errors = [errorMessage]
        };

        var json = JsonSerializer.Serialize(responseModel);
        await context.Response.WriteAsync(json);
    }
}