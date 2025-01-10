using Healthcare.Appointments.Domain.Contracts;
using Healthcare.Appointments.Domain.Entities;
using Healthcare.Appointments.Infrastructure.Commons;
using Healthcare.Appointments.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace Healthcare.Appointments.Infrastructure.Repositories;

public class UserRepository(ApplicationDbContext context,  UserManager<User> userManager, IConfiguration configuration) : IUserRepository
{
    public async Task<string> GetTokenAsync(User user)
    {

        var roles = await userManager.GetRolesAsync(user);
        return TokenGenerator.GetToken(user, roles,  configuration);
    }


    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return context.SaveChangesAsync(cancellationToken);
    }
}