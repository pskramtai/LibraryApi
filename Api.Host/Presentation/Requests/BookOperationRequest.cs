namespace Api.Host.Presentation.Requests;

public record BookOperationRequest(
    CreateBookRequest? CreateDetails,
    ModifyBookRequest? ModifyDetails,
    DeleteBookRequest? DeleteDetails
);