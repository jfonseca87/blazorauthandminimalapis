using BlazorAuth.Shared.Models;

namespace BlazorAuth.Client.Services;

public class BookDataService : IBookDataService
{
    private readonly IBaseDataService<Book> _baseDataService;
    private const string BOOK_BASE_URL = "api/book";

    public BookDataService(IBaseDataService<Book> baseDataService)
    {
        _baseDataService = baseDataService;
    }

    public async Task<ResponseModelData<int>> AddBook(Book book)
    {
        return await _baseDataService.Post<int>(BOOK_BASE_URL, book);
    }

    public async Task<ResponseModelData<IEnumerable<Book>>> GetBooks()
    {
        return await _baseDataService.Get<IEnumerable<Book>>(BOOK_BASE_URL);
    }
}