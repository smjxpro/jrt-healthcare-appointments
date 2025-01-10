using Healthcare.Appointments.Domain.Entities;

namespace Healthcare.Appointments.Domain.Contracts;

public interface IDoctorRepository: IRepository
{
    Task<List<Doctor>> GetAllAsync(int page, int pageSize, string? search, CancellationToken cancellationToken = default);
    Task<Doctor?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Doctor> AddAsync(Doctor doctor, CancellationToken cancellationToken = default);
    Task<Doctor> UpdateAsync(Doctor doctor, CancellationToken cancellationToken = default);
    Task DeleteAsync(Doctor doctor, CancellationToken cancellationToken = default);
}