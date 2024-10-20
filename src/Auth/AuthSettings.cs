using Microsoft.AspNetCore.Authentication;

namespace DemoApiNet9.Auth;

public static class AuthSettings
{
    public static AuthenticationBuilder AddApiKeyAuthentication(this AuthenticationBuilder authBuilder)
    {
        authBuilder.AddScheme<AuthenticationSchemeOptions, ApiKeyAuthenticationHandler>("ApiKey", options => { });

        return authBuilder;
    }

    public static IServiceCollection AddAuthorizationPolicies(this IServiceCollection services)
    {
        services.AddAuthorizationBuilder().AddPolicy("ApiKeyPolicy", policy =>
        {
            policy.AddAuthenticationSchemes("ApiKey");
            policy.RequireAuthenticatedUser();
        });

        return services;
    }
}
