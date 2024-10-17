namespace DemoApiNet9.V1;

public static partial class OceanWeatherEndpoints
{
    public static WebApplication MapOceansVersionTwoWeatherEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/weather-api/v2/oceans/")
                       .WithTags("Ocean Weather Endpoints")
                       .WithGroupName("v2");

        group.MapGet("/forcast", () =>
        {
            return Results.Ok();

        }).WithDescription("Gets weather forcasts for all cities")
          .RequireAuthorization();

        group.MapGet("/forcast/{ocean}", (string ocean) =>
        {
            return Results.Ok();
        }).WithDescription("Gets an ocean weather forcast")
          .RequireAuthorization();

        return app;
    }
}
