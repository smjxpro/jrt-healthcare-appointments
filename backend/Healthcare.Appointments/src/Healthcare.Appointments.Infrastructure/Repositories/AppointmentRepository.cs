using Healthcare.Appointments.Domain.Contracts;
using Healthcare.Appointments.Domain.Entities;
using Healthcare.Appointments.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Healthcare.Appointments.Infrastructure.Repositories;

public class AppointmentRepository(ApplicationDbContext context) : IAppointmentRepository
{
    public async Task<IEnumerable<Appointment>> GetAllAsync()
    {
        return await context.Appointments
            .Include(x => x.Doctor)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IEnumerable<Appointment>> GetByDoctorIdAsync(Guid doctorId)
    {
        return await context.Appointments
            .Include(x => x.Doctor)
            .Where(x => x.DoctorId == doctorId)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IEnumerable<Appointment>> GetByUserIdAsync(Guid userId)
    {
        return await context.Appointments
            .Include(x => x.Doctor)
            .Where(x => x.UserId == userId)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Appointment?> GetByIdAsync(Guid id)
    {
        return await context.Appointments
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Appointment> AddAsync(Appointment appointment)
    {
        await context.Appointments.AddAsync(appointment);
        await context.SaveChangesAsync();
        return appointment;
    }

    public async Task<Appointment> UpdateAsync(Appointment appointment)
    {
        context.Appointments.Update(appointment);
        await context.SaveChangesAsync();
        return appointment;
    }

    public async Task DeleteAsync(Appointment appointment)
    {
        context.Appointments.Remove(appointment);
        await context.SaveChangesAsync();
    }

    public async Task<Appointment?> GetByDoctorIdAndDateTimeAsync(Guid doctorId, DateTimeOffset dateTime)
    {
        return await context.Appointments
            .Include(x => x.Doctor)
            .FirstOrDefaultAsync(x =>
                x.DoctorId == doctorId && x.DateTime >= dateTime.AddMinutes(-15) &&
                x.DateTime <= dateTime.AddMinutes(15));
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return context.SaveChangesAsync(cancellationToken);
    }
}