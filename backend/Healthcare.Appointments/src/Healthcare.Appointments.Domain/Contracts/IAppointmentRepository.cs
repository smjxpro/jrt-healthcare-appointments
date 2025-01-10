using Healthcare.Appointments.Domain.Entities;

namespace Healthcare.Appointments.Domain.Contracts;

public interface IAppointmentRepository : IRepository
{
    Task<IEnumerable<Appointment>> GetAllAsync(int page, int pageSize, string? search, DateOnly? date, Guid? doctorId, Guid? userId, CancellationToken cancellationToken = default);
    Task<Appointment?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Appointment> AddAsync(Appointment appointment, CancellationToken cancellationToken = default);
    Task<Appointment> UpdateAsync(Appointment appointment, CancellationToken cancellationToken = default);
    Task DeleteAsync(Appointment appointment, CancellationToken cancellationToken = default);
    Task<Appointment?> GetByDoctorIdAndDateTimeAsync(Guid doctorId, DateTimeOffset dateTime, CancellationToken cancellationToken = default);
}