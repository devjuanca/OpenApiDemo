using Scalar.AspNetCore;

namespace DemoApiNet9.OpenApi;

public static class OpenApiRegister
{
    public static IServiceCollection AddApplicationOpenApi(this IServiceCollection services)
    {
        services.AddOpenApi("v1", options =>
        {
            options.AddDocumentTransformer((document, ctx, _) =>
            {
                document.Info.Title = "Weather API";
                document.Info.Description = "An API with weather features.";
                document.Info.Version = "v1";
                document.Info.Contact = new Microsoft.OpenApi.Models.OpenApiContact { Name = "Admin", Email = "admin@admin.com" };

                return Task.CompletedTask;
            });

            options.AddDocumentTransformer<SecuritySchemeTransformer>();
        });

        services.AddOpenApi("v2", options =>
        {
            options.AddDocumentTransformer((document, ctx, _) =>
            {
                document.Info.Title = "Weather API";
                document.Info.Description = "An API with weather features.";
                document.Info.Version = "v2";
                document.Info.Contact = new Microsoft.OpenApi.Models.OpenApiContact { Name = "Admin", Email = "admin@admin.com" };

                return Task.CompletedTask;
            });

            options.AddDocumentTransformer<SecuritySchemeTransformer>();
        });

        return services;
    }

    public static WebApplication MapOpenApiUI(this WebApplication app)
    {
        app.MapOpenApi(pattern: "/weather-api/openapi/{documentName}.json");

        app.MapScalarApiReference(opt =>
        {
            opt.WithTitle("Weather Api")
               .WithEndpointPrefix("/weather-api/scalar/{documentName}")
               .WithOpenApiRoutePattern("/weather-api/openapi/{documentName}.json")
               .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient)
               .WithDefaultOpenAllTags(false)
               .WithFavicon("/weather-api/assets/favicon-32.png")
               .WithTheme(ScalarTheme.DeepSpace);
        });

        return app;
    }
}