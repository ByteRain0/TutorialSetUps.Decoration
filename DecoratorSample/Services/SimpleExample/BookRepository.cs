using DecoratorSample.Models;

namespace DecoratorSample.Services.SimpleExample;

public class BookRepository : IBookRepository
{
    private readonly List<Book> _books;

    public BookRepository()
    {
        _books = new List<Book>();
    }
    
    public void SaveBook(Book book)
    {
        _books.Add(book);
    }
}