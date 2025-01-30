using MediatR;

namespace Api.Host.Application.Commands;

public interface IBookCommand<out T> : IRequest<T> where T : BookCommandResult;

public record BookCommandResult(bool Success, string? ErrorMessage = null);

