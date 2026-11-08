using Microsoft.Extensions.DependencyInjection;

namespace ArticlesAPI.Shared.Extensions;

public static class AuthorizationExtensions
{
    public static IServiceCollection AddApplicationAuthorization(
        this IServiceCollection services)
    {
        services.AddAuthorization(options =>
        {
            // Articles Permissions
            options.AddPolicy("Articles.Create",
                policy => policy.RequireClaim(
                    "permission", "Articles.Create"));

            options.AddPolicy("Articles.Read",
                policy => policy.RequireClaim(
                    "permission", "Articles.Read"));

            options.AddPolicy("Articles.Update",
                policy => policy.RequireClaim(
                    "permission", "Articles.Update"));

            options.AddPolicy("Articles.Delete",
                policy => policy.RequireClaim(
                    "permission", "Articles.Delete"));

            // Categories Permissions
            options.AddPolicy("Categories.Create",
                policy => policy.RequireClaim(
                    "permission", "Categories.Create"));

            options.AddPolicy("Categories.Update",
                policy => policy.RequireClaim(
                    "permission", "Categories.Update"));

            options.AddPolicy("Categories.Delete",
                policy => policy.RequireClaim(
                    "permission", "Categories.Delete"));
        });

        return services;
    }
}