using Healthcare.Appointments.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Healthcare.Appointments.Infrastructure.Data;
public static class DataSeeder
{
    public static void Seed(ApplicationDbContext context, ILogger<ApplicationDbContext> logger)
    {
        logger.LogInformation("Seeding database...");

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