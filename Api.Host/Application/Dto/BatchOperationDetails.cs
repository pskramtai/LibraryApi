using Api.Host.Application.Commands;

namespace Api.Host.Application.Dto;

public record BatchOperationDetails
(
    IReadOnlyCollection<IBookCommand<BookCommandResult>> Commands    
);