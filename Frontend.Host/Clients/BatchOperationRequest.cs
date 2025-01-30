namespace Frontend.Host.Clients;

public record BatchOperationRequest(
    CreateBookRequest? CreateDetails,
    ModifyBookRequest? ModifyDetails,
    DeleteBookRequest? DeleteDetails
);