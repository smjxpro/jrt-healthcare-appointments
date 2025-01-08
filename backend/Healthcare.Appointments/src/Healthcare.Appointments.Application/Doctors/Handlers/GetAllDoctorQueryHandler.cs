using Healthcare.Appointments.Application.Doctors.Dtos;
using Healthcare.Appointments.Application.Doctors.Queries;
using Healthcare.Appointments.Domain.Contracts;
using MapsterMapper;
using MediatR;

namespace Healthcare.Appointments.Application.Doctors.Handlers;

public class GetAllDoctorQueryHandler(IDoctorRepository doctorRepository, IMapper mapper): IRequestHandler<GetAllDoctorQuery, IEnumerable<DoctorDto>>
{
    public async Task<IEnumerable<DoctorDto>> Handle(GetAllDoctorQuery request, CancellationToken cancellationToken)
    {
        var doctors = await doctorRepository.GetAllAsync();
        return mapper.Map<IEnumerable<DoctorDto>>(doctors);
    }
}