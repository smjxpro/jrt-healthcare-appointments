using Healthcare.Appointments.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Healthcare.Appointments.Infrastructure.Data;
public static class DataSeeder
{
    public static void Seed(ApplicationDbContext context, UserManager<User> userManager, RoleManager<Role> roleManager, ILogger<ApplicationDbContext> logger)
    {
        logger.LogInformation("Seeding database...");

        if (!roleManager.Roles.Any())
        {
            var roles = new List<Role>
            {
                new() { Name = "Admin" },
                new() { Name = "User" }
            };

            foreach (var role in roles)
            {
                roleManager.CreateAsync(role).Wait();
            }
        }

        if (!userManager.Users.Any())
        {
            var user = new User
            {
                Name = "Admin",
                UserName = "admin",
                Email = "admin@localhost",
                EmailConfirmed = true
            };

            userManager.CreateAsync(user, "P@ssw0rd").Wait();
            userManager.AddToRoleAsync(user, "Admin").Wait();
        }

        if (!context.Doctors.Any())
        {
            var doctors = new List<Doctor>
            {
                new() { Name = "Dr. John Doe", Specialty = "Cardiology" },
                new() { Name = "Dr. Jane Doe", Specialty = "Dermatology" },
                new() { Name = "Dr. Bob Smith", Specialty = "Orthopedics" },
                new() { Name = "Dr. Alice Johnson", Specialty = "Gynecology" },
                new() { Name = "Dr. Tom Brown", Specialty = "Pediatrics" }
            };

            context.Doctors.AddRange(doctors);
        }

        context.SaveChanges();

        logger.LogInformation("Done seeding database...");
    }
}