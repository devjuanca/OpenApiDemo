﻿namespace DemoApiNet9.V1;

public static partial class OceanWeatherEndpoints
{
    public static WebApplication MapOceansVersionOneWeatherEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/weather-api/v1/oceans/")
                       .WithTags("Ocean Weather Endpoints")
                       .WithGroupName("v1");

        group.MapGet("/forcast", () =>
        {
            return Results.Ok();

        }).WithDescription("Gets weather forcasts for all cities");

        group.MapGet("/forcast/{ocean}", (string ocean) =>
        {
            return Results.Ok();
        }).WithDescription("Gets an ocean weather forcast"); ;

        return app;
    }
}
