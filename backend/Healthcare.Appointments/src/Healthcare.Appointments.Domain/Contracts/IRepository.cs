namespace Healthcare.Appointments.Domain.Contracts;

public interface IRepository
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}