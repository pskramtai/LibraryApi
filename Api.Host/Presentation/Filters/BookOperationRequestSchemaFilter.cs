using Api.Host.Presentation.Requests;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Api.Host.Presentation.Filters;

public class BookOperationRequestSchemaFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (context.Type == typeof(BookOperationRequest))
        {
            schema.Example = new OpenApiArray
            {
                new OpenApiObject
                {
                    ["CreateDetails"] = new OpenApiObject
                    {
                        ["Title"] = new OpenApiString("Test"),
                        ["Author"] = new OpenApiString("Test"),
                        ["ReleaseDate"] = new OpenApiString("2025-01-01")
                    },
                    ["ModifyDetails"] = new OpenApiNull(),
                    ["DeleteDetails"] = new OpenApiNull()
                },
                new OpenApiObject
                {
                    ["CreateDetails"] = new OpenApiNull(),
                    ["ModifyDetails"] = new OpenApiObject
                    {
                        ["Id"] = new OpenApiString(Guid.NewGuid().ToString()),
                        ["Title"] = new OpenApiString("Test"),
                        ["Author"] = new OpenApiString("Test"),
                        ["ReleaseDate"] = new OpenApiString("2025-01-01")
                    },
                    ["DeleteDetails"] = new OpenApiNull()
                },
                new OpenApiObject
                {
                    ["CreateDetails"] = new OpenApiNull(),
                    ["ModifyDetails"] = new OpenApiNull(),
                    ["DeleteDetails"] = new OpenApiObject
                    {
                        ["Id"] = new OpenApiString(Guid.NewGuid().ToString())
                    }
                }
            };
        }
    }
}