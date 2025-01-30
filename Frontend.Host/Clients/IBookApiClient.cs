using Refit;

namespace Frontend.Host.Clients;

public interface IBookApiClient
{
    [Get("/books")]
    Task<IReadOnlyCollection<BookResponse>> GetBookList();
    
    [Post("/books/batch")]
    Task<IReadOnlyCollection<BookOperationResponse>> SendBatch(IEnumerable<BookOperationRequest> requests);
}