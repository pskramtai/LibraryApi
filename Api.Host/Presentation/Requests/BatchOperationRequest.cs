namespace Api.Host.Presentation.Requests;

public record BatchOperationRequest(
    CreateBookRequest? CreateDetails,
    ModifyBookRequest? ModifyDetails,
    DeleteBookRequest? DeleteDetails
);