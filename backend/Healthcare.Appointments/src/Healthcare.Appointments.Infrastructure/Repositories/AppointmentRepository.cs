using Healthcare.Appointments.Domain.Contracts;
using Healthcare.Appointments.Domain.Entities;
using Healthcare.Appointments.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Healthcare.Appointments.Infrastructure.Repositories;

public class AppointmentRepository(ApplicationDbContext context) : IAppointmentRepository
{
    public async Task<IEnumerable<Appointment>> GetAllAsync(int page, int pageSize, string? search, DateOnly? date, Guid? doctorId, Guid? userId, CancellationToken cancellationToken = default)
    {
        search = search?.ToLower();
        return await context.Appointments
            .Include(x => x.Doctor)
            .Include(x => x.User)
            .Where(x => (search == null || x.Doctor.Name.ToLower().Contains(search) || x.Doctor.Specialty.ToLower().Contains(search) || x.User.Name.ToLower().Contains(search)) &&
                        (date == null || DateOnly.FromDateTime(x.DateTime.Date) == date) &&
                        (doctorId == null || x.DoctorId == doctorId) &&
                        (userId == null || x.UserId == userId))
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .OrderBy(x => x.DateTime)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task<Appointment?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await context.Appointments
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<Appointment> AddAsync(Appointment appointment, CancellationToken cancellationToken = default)
    {
        await context.Appointments.AddAsync(appointment, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return appointment;
    }

    public async Task<Appointment> UpdateAsync(Appointment appointment, CancellationToken cancellationToken = default)
    {
        context.Appointments.Update(appointment);
        await context.SaveChangesAsync(cancellationToken);
        return appointment;
    }

    public async Task DeleteAsync(Appointment appointment, CancellationToken cancellationToken = default)
    {
        context.Appointments.Remove(appointment);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<Appointment?> GetByDoctorIdAndDateTimeAsync(Guid doctorId, DateTimeOffset dateTime, CancellationToken cancellationToken = default)
    {
        return await context.Appointments
            .Include(x => x.Doctor)
            .FirstOrDefaultAsync(x =>
                x.DoctorId == doctorId && x.DateTime >= dateTime.AddMinutes(-15) &&
                x.DateTime <= dateTime.AddMinutes(15), cancellationToken);
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return context.SaveChangesAsync(cancellationToken);
    }


}