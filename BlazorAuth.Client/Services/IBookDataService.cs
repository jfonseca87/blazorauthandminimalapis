using BlazorAuth.Shared.Models;

namespace BlazorAuth.Client.Services;

public interface IBookDataService
{
    Task<ResponseModelData<IEnumerable<Book>>> GetBooks();
    Task<ResponseModelData<int>> AddBook(Book book);
}