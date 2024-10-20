namespace DemoApiNet9;

public static class CommonEndpoints
{
    public static WebApplication MapCommonEndpoints(this WebApplication app)
    {
        app.MapGet("/weather-api/scalar", (IConfiguration configuration) =>
        {
            var defaultVersion = configuration["DefaultVersion"] ?? "v1";

            return Results.Redirect($"/weather-api/scalar/{defaultVersion}");

        }).ExcludeFromDescription();

        app.MapGet("/weather-api", (IConfiguration configuration) =>
        {
            var defaultVersion = configuration["DefaultVersion"] ?? "v1";

            return Results.Redirect($"/weather-api/scalar/{defaultVersion}");

        }).ExcludeFromDescription();

        return app;
    }
}
