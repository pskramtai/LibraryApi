using Api.Host.Presentation.Requests;
using FluentValidation;

namespace Api.Host.Presentation.Validators;

public class BookOperationRequestValidator : AbstractValidator<BookOperationRequest>
{
    public BookOperationRequestValidator(
        IValidator<CreateBookRequest> createBookRequestValidator,
        IValidator<ModifyBookRequest> modifyBookRequestValidator,
        IValidator<DeleteBookRequest> deleteBookRequestValidator
    )
    {
        RuleFor(x => x)
            .Must(BeOfOneOperationType)
            .WithMessage("Only one operation type is allowed.");

        RuleFor(x => x.CreateDetails!)
            .SetValidator(createBookRequestValidator)
            .When(x => x.CreateDetails is not null);
        
        RuleFor(x => x.ModifyDetails!)
            .SetValidator(modifyBookRequestValidator)
            .When(x => x.ModifyDetails is not null);
        
        RuleFor(x => x.DeleteDetails!)
            .SetValidator(deleteBookRequestValidator)
            .When(x => x.DeleteDetails is not null);
    }

    private bool BeOfOneOperationType(BookOperationRequest request)
    {
        List<bool> properties =
        [
            request.CreateDetails is not null,
            request.ModifyDetails is not null,
            request.DeleteDetails is not null
        ];

        return properties.Count(x => x) == 1;
    }
}