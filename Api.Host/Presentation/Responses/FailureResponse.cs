namespace Api.Host.Presentation.Responses;

public record FailureResponse
(
    string Reason,
    string Message
);