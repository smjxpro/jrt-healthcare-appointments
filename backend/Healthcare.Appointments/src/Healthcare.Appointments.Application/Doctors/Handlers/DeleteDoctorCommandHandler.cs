using Healthcare.Appointments.Application.Commons.Exceptions;
using Healthcare.Appointments.Application.Doctors.Commands;
using Healthcare.Appointments.Domain.Contracts;
using MediatR;

namespace Healthcare.Appointments.Application.Doctors.Handlers;

public class DeleteDoctorCommandHandler(IDoctorRepository doctorRepository) : IRequestHandler<DeleteDoctorCommand>
{
    public async Task Handle(DeleteDoctorCommand request, CancellationToken cancellationToken)
    {
        var doctor = await doctorRepository.GetByIdAsync(request.Id);

        if (doctor == null)
        {
            throw new NotFoundException("Doctor not found");
        }

        await doctorRepository.DeleteAsync(doctor);
    }
}