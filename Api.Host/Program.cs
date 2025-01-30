using System.Text.Json.Serialization;
using Api.Host.Application.Services;
using Api.Host.Domain.Repositories;
using Api.Host.Domain.Services;
using Api.Host.Infrastructure;
using Api.Host.Infrastructure.Repositories;
using Api.Host.Presentation.Endpoints;
using Api.Host.Presentation.Middleware;
using FluentValidation;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services
    .AddOpenApi()
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .Configure<JsonOptions>(options =>
    {
        options.SerializerOptions.PropertyNameCaseInsensitive = true;
        options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
    })
    .AddValidatorsFromAssemblyContaining<Program>()
    .AddScoped<IBookBatchService, BookBatchService>()
    .AddScoped<IBookRepository, BookRepository>()
    .AddScoped<IBookService, BookService>()
    .AddSingleton<IBatchValidationService, BatchValidationService>()
    .AddPooledDbContextFactory<BookDbContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("DbConnectionString")))
    .AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());

builder.Services.AddLogging(cfg => cfg.AddConsole());

builder.Services.AddCors(options =>
{
    options.AddPolicy("BlazorApp",
        x => x.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

var app = builder.Build();

app.UseCors("BlazorApp");

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionMiddleware>();

app
    .RegisterBookBatchProcessingEndpoint()
    .RegisterGetBookListEndpoint();

app.Run();