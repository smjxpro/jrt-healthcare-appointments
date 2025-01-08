using Healthcare.Appointments.Domain.Entities;

namespace Healthcare.Appointments.Domain.Contracts;

public interface IAppointmentRepository: IRepository
{
    Task<IEnumerable<Appointment>> GetAllAsync();
    Task<IEnumerable<Appointment>> GetByDoctorIdAsync(Guid doctorId);
    Task<IEnumerable<Appointment>> GetByUserIdAsync(Guid userId);
    Task<Appointment?> GetByIdAsync(Guid id);
    Task<Appointment> AddAsync(Appointment appointment);
    Task<Appointment> UpdateAsync(Appointment appointment);
    Task DeleteAsync(Appointment appointment);
    Task<Appointment?> GetByDoctorIdAndDateTimeAsync(Guid doctorId, DateTimeOffset dateTime);
}