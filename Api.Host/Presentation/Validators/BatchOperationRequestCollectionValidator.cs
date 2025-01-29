using Api.Host.Presentation.Requests;
using FluentValidation;

namespace Api.Host.Presentation.Validators;

public class BatchOperationRequestCollectionValidator : AbstractValidator<IReadOnlyCollection<BatchOperationRequest>>
{
    public BatchOperationRequestCollectionValidator(
        IValidator<BatchOperationRequest> batchOperationRequestValidator
    )
    {
        RuleForEach(x => x)
            .SetValidator(batchOperationRequestValidator);
    }
}