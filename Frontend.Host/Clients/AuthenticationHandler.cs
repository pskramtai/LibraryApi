using System.Net.Http.Headers;

namespace Frontend.Host.Clients;

public class AuthenticationHandler : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var token =
            "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJ0ZXN0IiwiaWF0IjoxNzM4MTk5NDkyLCJleHAiOjE3Njk3MzU0OTIsImF1ZCI6InRlc3QifQ.4UHnrPJDvHFnDrxP6V4mJsPlEiAhsZRPBnBUKKaFCyY";

        if (!string.IsNullOrEmpty(token))
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        return await base.SendAsync(request, cancellationToken);
    }
}