using Api.Host.Presentation.Requests;
using FluentValidation;

namespace Api.Host.Presentation.Validators;

public class ModifyBookRequestValidator : AbstractValidator<ModifyBookRequest>
{
    public ModifyBookRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
        
        RuleFor(x => x.Author)
            .NotEmpty();
        
        RuleFor(x => x.Title)
            .NotEmpty();
        
        RuleFor(x => x.ReleaseDate)
            .NotNull();
    }
}