using System.Text.Json.Serialization;
using Api.Host.Presentation.Configuration;
using Api.Host.Presentation.Endpoints;
using Api.Host.Presentation.Filters;
using Api.Host.Presentation.Middleware;
using Microsoft.AspNetCore.Http.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddOpenApi()
    .AddEndpointsApiExplorer()
    .AddSwaggerGen(options =>
    {
        options.SchemaFilter<BookOperationRequestSchemaFilter>();
    })
    .Configure<JsonOptions>(options =>
    {
        options.SerializerOptions.PropertyNameCaseInsensitive = true;
        options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });
    
builder.Services    
    .ConfigureServices()
    .ConfigureRepositories(builder.Configuration);

builder.Services.AddLogging(cfg => cfg.AddConsole());

builder.Services.AddCors(options =>
{
    options.AddPolicy("BlazorApp",
        x => x.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

builder.Services.ConfigureAuthentication();
builder.Services.AddAuthorization();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
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