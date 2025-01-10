using Healthcare.Appointments.Domain.Contracts;
using Healthcare.Appointments.Domain.Entities;
using Healthcare.Appointments.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Healthcare.Appointments.Infrastructure.Repositories;

public class DoctorRepository(ApplicationDbContext context) : IDoctorRepository
{
    public async Task<List<Doctor>> GetAllAsync(int page, int pageSize, string? search, CancellationToken cancellationToken = default)
    {
        search = search?.ToLower();
        return await context.Doctors
            .Where(x => search == null || x.Name.ToLower().Contains(search) || x.Specialty.ToLower().Contains(search))
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task<Doctor?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await context.Doctors.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<Doctor> AddAsync(Doctor doctor, CancellationToken cancellationToken = default)
    {
        await context.Doctors.AddAsync(doctor, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return doctor;
    }

    public async Task<Doctor> UpdateAsync(Doctor doctor, CancellationToken cancellationToken = default)
    {
        context.Doctors.Update(doctor);
        await context.SaveChangesAsync(cancellationToken);
        return doctor;
    }


    public async Task DeleteAsync(Doctor doctor, CancellationToken cancellationToken = default)
    {
        context.Doctors.Remove(doctor);
        await context.SaveChangesAsync(cancellationToken);
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return context.SaveChangesAsync(cancellationToken);
    }
}