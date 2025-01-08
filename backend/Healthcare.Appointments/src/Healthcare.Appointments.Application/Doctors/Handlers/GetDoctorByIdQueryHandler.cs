using Healthcare.Appointments.Application.Commons.Exceptions;
using Healthcare.Appointments.Application.Doctors.Dtos;
using Healthcare.Appointments.Application.Doctors.Queries;
using Healthcare.Appointments.Domain.Contracts;
using MapsterMapper;
using MediatR;

namespace Healthcare.Appointments.Application.Doctors.Handlers;

public class GetDoctorByIdQueryHandler(IDoctorRepository doctorRepository, IMapper mapper)
    : IRequestHandler<GetDoctorByIdQuery, DoctorDto>
{
    public async Task<DoctorDto> Handle(GetDoctorByIdQuery request, CancellationToken cancellationToken)
    {
        var doctor = await doctorRepository.GetByIdAsync(request.Id);

        if (doctor == null)
        {
            throw new NotFoundException("Doctor not found");
        }

        return mapper.Map<DoctorDto>(doctor);
    }
}