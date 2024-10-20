using DemoOpenApiNet9.Dto;
using DemoOpenApiNet9.Services;

namespace DemoApiNet9.V1;

public static partial class CityWeatherEndpoints
{
    public static WebApplication MapCitiesVersionTwoWeatherEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/weather-api/v2/cities/")
                       .WithTags("Cities Weather Endpoints")
                       .WithGroupName("v2");

        group.MapGet("/forecast", (WeatherService service) =>
        {
            return service.GetWeatherForecasts();

        }).Produces<List<WeatherForecast>>()
          .WithDescription("Gets weather forcasts for all cities")
          .WithSummary("Cities Weather Forcast")
          .RequireAuthorization();



        group.MapGet("/forecast/{city}", (string city, WeatherService service) =>
        {
            var forecast = service.GetWeatherForecast(city);

            if (forecast != null)
            {
                return Results.Ok(forecast);
            }
            return Results.NotFound();

        }).Produces<WeatherForecast>()
          .WithDescription("Gets a city weather forcast")
          .WithSummary("City Weather Forcast")
          .RequireAuthorization();

        group.MapPost("/forecast", (CreateWeatherForecastCommand newforecast, WeatherService service) =>
        {
            service.AddWeatherForecast(newforecast.Map());

            return Results.Created();

        }).Produces(201)
          .WithDescription("Creates a city weather forecast")
          .WithSummary("Creates Weather Forcast")
          .RequireAuthorization();

        group.MapDelete("/forecast", (string city, WeatherService service) =>
        {
            service.DeleteForcast(city);

            return Results.NoContent();

        }).Produces(204)
          .WithDescription("Deletes a weather forcast")
          .WithSummary("Deletes Weather Forcast")
          .RequireAuthorization();

        return app;
    }
}