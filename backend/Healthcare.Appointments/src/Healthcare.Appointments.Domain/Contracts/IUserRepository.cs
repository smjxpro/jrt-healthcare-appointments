using Healthcare.Appointments.Domain.Entities;

namespace Healthcare.Appointments.Domain.Contracts;

public interface IUserRepository : IRepository
{
    Task<string> GetTokenAsync(User user, CancellationToken cancellationToken = default);

    Task<IEnumerable<User>> GetUsersAsync(int page, int pageSize, string? search, CancellationToken cancellationToken = default);

}