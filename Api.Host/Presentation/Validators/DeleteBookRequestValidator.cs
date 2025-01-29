using Api.Host.Presentation.Requests;
using FluentValidation;

namespace Api.Host.Presentation.Validators;

public class DeleteBookRequestValidator : AbstractValidator<DeleteBookRequest>
{
    public DeleteBookRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }
}