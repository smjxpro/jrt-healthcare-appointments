using Healthcare.Appointments.Domain.Contracts;
using Healthcare.Appointments.Domain.Entities;
using Healthcare.Appointments.Infrastructure.Commons;
using Healthcare.Appointments.Infrastructure.Data;
using Microsoft.Extensions.Configuration;

namespace Healthcare.Appointments.Infrastructure.Repositories;

public class UserRepository(ApplicationDbContext context, IConfiguration configuration) : IUserRepository
{
    public string GetTokenAsync(User user)
    {
        return TokenGenerator.GetToken(user, configuration);
    }


    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return context.SaveChangesAsync(cancellationToken);
    }
}