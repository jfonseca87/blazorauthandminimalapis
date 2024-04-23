using BlazorAuth.Shared.Models;

namespace BlazorAuth.Api.Repositories;

public class BookRepository : IBookRepository
{
    private readonly List<Book> _books;

    public BookRepository()
    {
        _books = new List<Book>
        {
            new Book{ Id = 1,  Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Pages = 180},
            new Book{ Id = 2,  Title = "To Kill a Mockingbird", Author = "Harper Lee", Pages = 281},
            new Book{ Id = 3,  Title = "1984", Author = "George Orwell", Pages =328},
            new Book{ Id = 4,  Title = "Pride and Prejudice", Author = "Jane Austen", Pages = 432},
            new Book{ Id = 5,  Title = "The Catcher in the Rye", Author = "J.D. Salinger", Pages = 234},
            new Book{ Id = 6,  Title = "The Lord of the Rings", Author = "J.R.R. Tolkien", Pages = 768},
            new Book{ Id = 7,  Title = "The Hobbit", Author = "J.R.R. Tolkien", Pages = 374},
            new Book{ Id = 8,  Title = "The Da Vinci Code", Author = "Dan Brown", Pages = 432},
            new Book{ Id = 9,  Title = "The Girl with the Dragon Tattoo", Author = "Stieg Larsson", Pages = 432},
            new Book{ Id = 10, Title = "The Hunger Games", Author = "Suzanne Collins", Pages = 432},
            new Book{ Id = 11, Title = "The Chronicles of Narnia, Book 1", Author = "C.S. Lewis", Pages = 432}
        };
    }

    public IEnumerable<Book> GetBooks() => _books;

    public Book AddBook(Book book)
    {
        int counter = _books.Count;
        Book newBook = book with { Id = counter + 1 };
        _books.Add(newBook);

        return newBook;
    }
}