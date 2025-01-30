using Api.Host.Presentation.Requests;
using FluentValidation;

namespace Api.Host.Presentation.Validators;

public class BatchOperationRequestCollectionValidator : AbstractValidator<IReadOnlyCollection<BookOperationRequest>>
{
    public BatchOperationRequestCollectionValidator(
        IValidator<BookOperationRequest> batchOperationRequestValidator
    )
    {
        RuleForEach(x => x)
            .SetValidator(batchOperationRequestValidator);
    }
}