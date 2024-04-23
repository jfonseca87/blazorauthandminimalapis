using BlazorAuth.Api.Extensions;
using BlazorAuth.Api.Helpers;
using BlazorAuth.Shared.Models;

namespace BlazorAuth.Api.Extensions.Filters;

public static class RouteObjectValidatorHandler
{
    public static RouteHandlerBuilder Validate<T>(this RouteHandlerBuilder builder)
    {
        builder.AddEndpointFilter(async (context, next) =>
        {
            var argument = context.Arguments.OfType<T>().FirstOrDefault()!;
            var responseValidation = argument.Validate();

            if (responseValidation.Count != 0)
            {
                return Results.BadRequest(new ResponseModel
                {
                    Success = false,
                    Errors = [.. responseValidation]
                });
            }

            return await next(context);
        });

        return builder;
    }
}