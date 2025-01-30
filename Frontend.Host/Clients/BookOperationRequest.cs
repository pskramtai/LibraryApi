namespace Frontend.Host.Clients;

public record BookOperationRequest(
    CreateBookRequest? CreateDetails,
    ModifyBookRequest? ModifyDetails,
    DeleteBookRequest? DeleteDetails
);