using DemoApiNet9;
using DemoApiNet9.Auth;
using DemoApiNet9.OpenApi;
using DemoApiNet9.Services;
using DemoApiNet9.V1;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<WeatherRepository>();

builder.Services.AddSingleton<WeatherService>();

builder.Services.AddAuthentication()
                .AddApiKeyAuthentication();

builder.Services.AddAuthorizationPolicies();

builder.Services.AddAuthorization();

builder.Services.AddApplicationOpenApi();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

var app = builder.Build();

app.UseCors();

app.UseStaticFiles();

app.UseHttpsRedirection();

app.MapOpenApiUI();

app.MapCitiesVersionOneWeatherEndpoints();

app.MapCitiesVersionTwoWeatherEndpoints();

app.MapOceansVersionOneWeatherEndpoints();

app.MapOceansVersionTwoWeatherEndpoints();

app.MapCommonEndpoints();

app.UseAuthentication();

app.UseAuthorization();

app.MapShortCircuit(200, "/weather-api/assets/favicon-32.png");

app.Run();