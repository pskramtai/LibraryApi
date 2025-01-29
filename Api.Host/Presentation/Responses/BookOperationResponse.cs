namespace Api.Host.Presentation.Responses;

public record BookOperationResponse
(
    bool Success,
    BookResponse? Result
);