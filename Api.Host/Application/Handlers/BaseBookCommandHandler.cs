using Api.Host.Application.Commands;
using MediatR;

namespace Api.Host.Application.Handlers;

public abstract class BaseBookCommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, TResponse> 
    where TCommand : IBookCommand<TResponse> 
    where TResponse : BookCommandResult
{
    public async Task<TResponse> Handle(TCommand request, CancellationToken cancellationToken)
    {
        try
        {
            return await PerformOperationAsync(request);
        }
        catch
        {
            return (TResponse) new BookCommandResult(false);
        }
    }
    
    protected abstract Task<TResponse> PerformOperationAsync(TCommand command);
}