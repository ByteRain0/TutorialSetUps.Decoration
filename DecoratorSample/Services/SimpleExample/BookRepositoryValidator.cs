using DecoratorSample.Models;

namespace DecoratorSample.Services.SimpleExample;

public class BookRepositoryValidator : IBookRepository
{
    private readonly IBookRepository _bookRepository;

    public BookRepositoryValidator(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public void SaveBook(Book book)
    {
        if (book.Id < 0)
        {
            throw new InvalidOperationException("Id cannot be less than 0");
        }
        _bookRepository.SaveBook(book);
    }
}