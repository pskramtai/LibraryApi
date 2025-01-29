using Api.Host.Application.Commands;
using MediatR;

namespace Api.Host.Application.Handlers;

public abstract class BaseBookCommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, TResponse> 
    where TCommand : IBookCommand<TResponse> 
    where TResponse : BookCommandResult
{
    public async Task<TResponse> Handle(TCommand request, CancellationToken cancellationToken)
    {
        BookCommandResult result;

        try
        {
            result = await PerformOperationAsync(request);
        }
        catch
        {
            result = new BookCommandResult(false);
        }
        
        return (TResponse) result;
    }
    
    protected abstract Task<TResponse> PerformOperationAsync(TCommand command);
}