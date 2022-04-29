using DecoratorSample.Models;

namespace DecoratorSample.Services.SimpleExample;

public interface IBookRepository
{
    void SaveBook(Book book);
}