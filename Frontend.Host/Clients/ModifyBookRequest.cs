namespace Frontend.Host.Clients;

public record ModifyBookRequest(
    Guid? Id,
    string Title,
    string Author,
    DateOnly? ReleaseDate
);