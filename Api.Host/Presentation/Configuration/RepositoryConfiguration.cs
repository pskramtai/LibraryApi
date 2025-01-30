using Api.Host.Domain.Repositories;
using Api.Host.Infrastructure;
using Api.Host.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Api.Host.Presentation.Configuration;

public static class RepositoryConfiguration
{
    public static IServiceCollection ConfigureRepositories(this IServiceCollection services,
        ConfigurationManager configurationManager) =>
        services
            .AddScoped<IBookRepository, BookRepository>()
            .AddPooledDbContextFactory<BookDbContext>(options =>
                options.UseNpgsql(configurationManager.GetConnectionString("DbConnectionString")));
}