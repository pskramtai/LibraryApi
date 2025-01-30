using Frontend.Host.Services;

namespace Frontend.Host.Configuration;

public static class ServiceConfiguration
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services) =>
        services
            .AddScoped<IBookService, BookService>()
            .AddScoped<StateContainer>();
}