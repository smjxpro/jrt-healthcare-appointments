using Healthcare.Appointments.Domain.Contracts;
using Healthcare.Appointments.Domain.Entities;
using Healthcare.Appointments.Infrastructure.Commons;
using Healthcare.Appointments.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Healthcare.Appointments.Infrastructure.Repositories;

public class UserRepository(ApplicationDbContext context, UserManager<User> userManager, IConfiguration configuration) : IUserRepository
{

    public async Task<string> GetTokenAsync(User user, CancellationToken cancellationToken = default)
    {

        var roles = await userManager.GetRolesAsync(user);
        return TokenGenerator.GetToken(user, roles, configuration);
    }

    public async Task<IEnumerable<User>> GetUsersAsync(int page, int pageSize, string? search, CancellationToken cancellationToken = default)
    {
        search = search?.ToLower();
        return await userManager.Users
            .Where(u => search == null || u.UserName.ToLower().Contains(search) || u.Email.ToLower().Contains(search) || u.PhoneNumber.Contains(search) || u.Name.ToLower().Contains(search))
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return context.SaveChangesAsync(cancellationToken);
    }
}