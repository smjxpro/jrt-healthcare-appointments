using Healthcare.Appointments.Domain.Entities;

namespace Healthcare.Appointments.Domain.Contracts;

public interface IDoctorRepository: IRepository
{
    Task<List<Doctor>> GetAllAsync();
    Task<Doctor?> GetByIdAsync(Guid id);
    Task<Doctor> AddAsync(Doctor doctor);
    Task<Doctor> UpdateAsync(Doctor doctor);
    Task DeleteAsync(Doctor doctor);
}