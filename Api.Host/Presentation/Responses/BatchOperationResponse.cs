using Api.Host.Application.Commands;

namespace Api.Host.Presentation.Responses;

public record BatchOperationResponse
(
    IReadOnlyCollection<BookCommandResult> Results
);