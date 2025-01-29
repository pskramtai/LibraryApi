using Api.Host.Domain.Exceptions;
using Api.Host.Presentation.Responses;

namespace Api.Host.Presentation.Mappers;

public static class ExceptionToResponseMapperExtensions
{
    public static FailureResponse ToResponse(this ConflictingOperationsException exception) =>
        new("Conflicting operations", exception.Message);
}