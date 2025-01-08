using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Healthcare.Appointments.Infrastructure.Data;
public static class DbInitializer
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context = new ApplicationDbContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<ApplicationDbContext>>());
        var logger = serviceProvider.GetRequiredService<ILogger<ApplicationDbContext>>();
        if (context == null)
        {
            throw new ArgumentNullException(nameof(context));
        }

        if (logger == null)
        {
            throw new ArgumentNullException(nameof(logger));
        }

        context.Database.Migrate();

        DataSeeder.Seed(context, logger);
    }
}