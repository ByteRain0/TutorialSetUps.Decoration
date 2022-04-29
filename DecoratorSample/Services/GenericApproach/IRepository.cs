namespace DecoratorSample.Services.GenericApproach;

public interface IRepository<T> where T : class
{
    void Save(T entity);
}