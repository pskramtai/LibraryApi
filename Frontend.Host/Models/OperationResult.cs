namespace Frontend.Host.Models;

public record OperationResult
(
    bool Success,
    string? ErrorMessage = null
);