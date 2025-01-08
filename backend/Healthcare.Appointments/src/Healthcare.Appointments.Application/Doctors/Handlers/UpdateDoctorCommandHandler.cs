using Healthcare.Appointments.Application.Commons.Exceptions;
using Healthcare.Appointments.Application.Doctors.Commands;
using Healthcare.Appointments.Application.Doctors.Dtos;
using Healthcare.Appointments.Domain.Contracts;
using MapsterMapper;
using MediatR;

namespace Healthcare.Appointments.Application.Doctors.Handlers;

public class UpdateDoctorCommandHandler(IDoctorRepository doctorRepository, IMapper mapper): IRequestHandler<UpdateDoctorCommand, DoctorDto>
{
    public async Task<DoctorDto> Handle(UpdateDoctorCommand request, CancellationToken cancellationToken)
    {
        var doctor = await doctorRepository.GetByIdAsync(request.Id);
        if (doctor == null)
        {
            throw new NotFoundException("Doctor not found");
        }
        
        mapper.Map(request, doctor);
        var updatedDoctor = await doctorRepository.UpdateAsync(doctor);
        return mapper.Map<DoctorDto>(updatedDoctor);
    }
}