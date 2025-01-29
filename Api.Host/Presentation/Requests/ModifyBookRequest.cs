namespace Api.Host.Presentation.Requests;

public record ModifyBookRequest(
    Guid? Id,
    string Title,
    string Author,
    DateOnly? ReleaseDate
);