using DecoratorSample.Models;

namespace DecoratorSample.Services.GenericApproach;

public class GenericBookRepository : IRepository<Book>
{
    public void Save(Book entity)
    {
        Console.WriteLine("Executed code some code");
    }
}