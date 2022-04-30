using FluentValidation;

namespace DecoratorSample.Services.GenericApproach;

public class GenericRepositoryValidator<T> : IRepository<T> where T : class
{
    private readonly IRepository<T> _bookRepository;

    private readonly IEnumerable<IValidator<T>> _validators;

    public GenericRepositoryValidator(IRepository<T> bookRepository, IEnumerable<IValidator<T>> validators)
    {
        _bookRepository = bookRepository;
        _validators = validators;
    }

    public void Save(T entity)
    {
        var context = new ValidationContext<T>(entity);
        
        var failures = _validators
            .Select(v => v.Validate(context))
            .SelectMany(result => result.Errors)
            .Where(f => f != null)
            .ToList();
        
        if (failures.Count != 0)
        {
            throw new ValidationException(failures);
        }
        
        _bookRepository.Save(entity);
    }
}