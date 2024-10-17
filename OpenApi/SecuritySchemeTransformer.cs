using Microsoft.AspNetCore.OpenApi;
using Microsoft.OpenApi.Models;

namespace DemoApiNet9.OpenApi;

internal sealed class SecuritySchemeTransformer : IOpenApiDocumentTransformer
{
    public Task TransformAsync(OpenApiDocument document, OpenApiDocumentTransformerContext context, CancellationToken cancellationToken)
    {
        var requirements = new Dictionary<string, OpenApiSecurityScheme>
        {
            ["ApiKey"] = new OpenApiSecurityScheme
            {
                Name = "x-weather-key",
                Description = "x-weather-key must be provided",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "ApiKey",
                In = ParameterLocation.Header,
                BearerFormat = "Api Key",

            },
            ["Bearer"] = new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Description = "JWT Authorization header using the Bearer scheme. Example: \"Bearer {token}\"",
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
            }
        };
        document.Components ??= new OpenApiComponents();

        document.Components.SecuritySchemes = requirements;

        return Task.CompletedTask;
    }
}
