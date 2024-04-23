using BlazorAuth.Api.Extensions.Filters;
using BlazorAuth.Api.Repositories;
using BlazorAuth.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlazorAuth.Api.Handlers;

public static class BookHandlers
{
    public static IEndpointRouteBuilder MapBookRoutes(this IEndpointRouteBuilder app)
    {
        app.MapGet("/", GetBooks)
            .RequireAuthorization()
            .WithName("GetBooks")
            .WithOpenApi();

        app.MapPost("/", AddBook)
            .RequireAuthorization()
            .Validate<Book>()
            .WithName("AddBook")
            .WithOpenApi();

        return app;
    }

    public static IResult GetBooks([FromServices] IBookRepository bookRepository)
    {
        var result = bookRepository.GetBooks();
        return Results.Ok(new ResponseModelData<IEnumerable<Book>> 
        {
            Success = true,
            Data = result,
        });
    }

    public static IResult AddBook([FromServices] IBookRepository bookRepository, [FromBody] Book book)
    {
        var response = bookRepository.AddBook(book);
        return Results.Ok(new ResponseModelData<int>
        {
            Success = true,
            Data = response.Id,
        });
    }
}