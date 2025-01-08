using Healthcare.Appointments.Domain.Contracts;
using Healthcare.Appointments.Domain.Entities;
using Healthcare.Appointments.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Healthcare.Appointments.Infrastructure.Repositories;

public class DoctorRepository(ApplicationDbContext context): IDoctorRepository
{
    public async Task<List<Doctor>> GetAllAsync()
    {
        return await context.Doctors.ToListAsync();
    }

    public async Task<Doctor?> GetByIdAsync(Guid id)
    {
        return await context.Doctors.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Doctor> AddAsync(Doctor doctor)
    {
        await context.Doctors.AddAsync(doctor);
        await context.SaveChangesAsync();
        return doctor;
    }

    public async Task<Doctor> UpdateAsync(Doctor doctor)
    {
        context.Doctors.Update(doctor);
        await context.SaveChangesAsync();
        return doctor;
    }

    public async Task DeleteAsync(Doctor doctor)
    {
        context.Doctors.Remove(doctor);
        await context.SaveChangesAsync();
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return context.SaveChangesAsync(cancellationToken);
    }
}