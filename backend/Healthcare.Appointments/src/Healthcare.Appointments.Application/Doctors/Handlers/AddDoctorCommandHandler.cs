using Healthcare.Appointments.Application.Doctors.Commands;
using Healthcare.Appointments.Application.Doctors.Dtos;
using Healthcare.Appointments.Domain.Contracts;
using Healthcare.Appointments.Domain.Entities;
using MapsterMapper;
using MediatR;

namespace Healthcare.Appointments.Application.Doctors.Handlers;

public class AddDoctorCommandHandler(IDoctorRepository doctorRepository, IMapper mapper)
    : IRequestHandler<AddDoctorCommand, DoctorDto>
{
    public async Task<DoctorDto> Handle(AddDoctorCommand request, CancellationToken cancellationToken)
    {
        var doctor = await doctorRepository.AddAsync(mapper.Map<Doctor>(request));
        return mapper.Map<DoctorDto>(doctor);
    }
}