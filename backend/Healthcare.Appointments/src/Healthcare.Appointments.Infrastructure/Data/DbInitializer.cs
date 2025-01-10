using Healthcare.Appointments.Domain.Entities;
using Microsoft.AspNetCore.Identity;
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

        using var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
        using var roleManager = serviceProvider.GetRequiredService<RoleManager<Role>>();

        var logger = serviceProvider.GetRequiredService<ILogger<ApplicationDbContext>>();

        if (context == null)
        {
            throw new ArgumentNullException(nameof(context));
        }

        if (userManager == null)
        {
            throw new ArgumentNullException(nameof(userManager));
        }

        if (roleManager == null)
        {
            throw new ArgumentNullException(nameof(roleManager));
        }

        if (logger == null)
        {
            throw new ArgumentNullException(nameof(logger));
        }

        context.Database.Migrate();

        DataSeeder.Seed(context, userManager, roleManager, logger);
    }
}