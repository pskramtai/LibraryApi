using Api.Host.Application.Services;
using Api.Host.Domain.Services;
using FluentValidation;

namespace Api.Host.Presentation.Configuration;

public static class ServiceConfiguration
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services) =>
        services
            .AddValidatorsFromAssemblyContaining<Program>()
            .AddScoped<IBookBatchService, BookBatchService>()
            .AddScoped<IBookService, BookService>()
            .AddSingleton<IBatchValidationService, BatchValidationService>()
            .AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());
}