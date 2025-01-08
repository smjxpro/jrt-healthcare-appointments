using Healthcare.Appointments.Infrastructure.Data;

namespace Healthcare.Appointments.API;

public static class WebApplicationExtension
{
    public static void ConfigurePipeline(this WebApplication app, IConfiguration configuration)
    {
        // if (app.Environment.IsProduction())
        // {
        using var scope = app.Services.CreateScope();
        var services = scope.ServiceProvider;

        DbInitializer.Initialize(services);
        // }

        app.UseHttpsRedirection();

        // if (!app.Environment.IsDevelopment())
        // {
        app.UseExceptionHandler("/error");
        // }

        app.UseStaticFiles();

        app.UseCors("AllowAll");

        app.UseAuthentication();

        app.UseAuthorization();

        app.MapControllers();

        app.MapOpenApi("/openapi/{documentName}.json");

        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/openapi/v1.json", "Healthcare Appointments API");
            options.RoutePrefix = string.Empty;
            options.EnablePersistAuthorization();
        });
    }
}