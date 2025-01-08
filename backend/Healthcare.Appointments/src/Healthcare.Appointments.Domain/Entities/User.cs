using Microsoft.AspNetCore.Identity;

namespace Healthcare.Appointments.Domain.Entities;

public class User : IdentityUser<Guid>
{
    public string Name { get; set; }
}