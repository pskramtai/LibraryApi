using Api.Host.Presentation.Requests;
using FluentValidation;

namespace Api.Host.Presentation.Validators;

public class CreateBookRequestValidator : AbstractValidator<CreateBookRequest>
{
    public CreateBookRequestValidator()
    {
        RuleFor(x => x.Author)
            .NotEmpty();
        
        RuleFor(x => x.Title)
            .NotEmpty();
        
        RuleFor(x => x.ReleaseDate)
            .NotNull();
    }
}