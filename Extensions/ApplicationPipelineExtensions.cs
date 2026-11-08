using ArticlesAPI.Infrastructure.Middlewares;

namespace ArticlesAPI.Shared.Extensions;

public static class ApplicationPipelineExtensions
{
    public static WebApplication UseApplicationPipeline(
        this WebApplication app)
    {
        // Global Exception Middleware
        app.UseMiddleware<GlobalExceptionMiddleware>();

        // Swagger
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.MapOpenApi();
        }

        // HTTPS
        app.UseHttpsRedirection();

        // Authentication
        app.UseAuthentication();

        // Authorization
        app.UseAuthorization();

        return app;
    }
}