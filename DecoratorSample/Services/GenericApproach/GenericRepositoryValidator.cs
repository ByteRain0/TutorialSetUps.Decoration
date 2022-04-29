namespace DecoratorSample.Services.GenericApproach;

public class GenericRepositoryValidator<T> : IRepository<T> where T : class
{
    private readonly IRepository<T> _bookRepository;


    public GenericRepositoryValidator(IRepository<T> bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public void Save(T entity)
    {
        Console.WriteLine("Test this thing out.");
        // Do some validation before hand
        _bookRepository.Save(entity);
    }
}