namespace Api.Host.Presentation.Responses;

public record BookResponse
(
    Guid Id,
    string Title,
    string Author,
    DateOnly ReleaseDate    
);