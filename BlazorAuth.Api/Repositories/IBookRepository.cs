using BlazorAuth.Shared.Models;

namespace BlazorAuth.Api.Repositories;

public interface IBookRepository
{
    IEnumerable<Book> GetBooks();
    Book AddBook(Book book);
}