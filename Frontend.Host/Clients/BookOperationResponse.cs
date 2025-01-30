namespace Frontend.Host.Clients;

public record BookOperationResponse
(
    bool Success,
    BookResponse? Result
);