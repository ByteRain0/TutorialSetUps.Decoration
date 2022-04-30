using DecoratorSample.Models;
using FluentValidation;

namespace DecoratorSample.Services.GenericApproach;

public class BookValidator : AbstractValidator<Book>
{
    public BookValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty();

        RuleFor(x => x.AuthorName)
            .NotEmpty();
    }
}