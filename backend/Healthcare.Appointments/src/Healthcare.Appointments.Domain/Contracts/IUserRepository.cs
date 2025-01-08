using Healthcare.Appointments.Domain.Entities;

namespace Healthcare.Appointments.Domain.Contracts;

public interface IUserRepository : IRepository
{
    string GetTokenAsync(User user);
}