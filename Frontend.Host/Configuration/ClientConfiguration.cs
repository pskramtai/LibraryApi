using Frontend.Host.Clients;
using Refit;

namespace Frontend.Host.Configuration;

public static class ClientConfiguration
{
    public static IServiceCollection ConfigureClients(this IServiceCollection services)
    {
        services.
            AddSingleton<AuthenticationHandler>()
            .AddRefitClient<IBookApiClient>()
            .ConfigureHttpClient(x => x.BaseAddress = new Uri("http://localhost:5206"))
            .AddHttpMessageHandler<AuthenticationHandler>();

        return services;
    }
}