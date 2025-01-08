using Healthcare.Appointments.Application.Appointments.Dtos;
using Healthcare.Appointments.Application.Appointments.Queries;
using Healthcare.Appointments.Domain.Contracts;
using MapsterMapper;
using MediatR;

namespace Healthcare.Appointments.Application.Appointments.Handlers;

public class GetAllAppointmentByDoctorQueryHandler(IAppointmentRepository appointmentRepository, IMapper mapper): IRequestHandler<GetAllAppointmentByDoctorQuery, IEnumerable<AppointmentDto>>
{
    public async Task<IEnumerable<AppointmentDto>> Handle(GetAllAppointmentByDoctorQuery request, CancellationToken cancellationToken)
    {
        var appointments = await appointmentRepository.GetByDoctorIdAsync(request.DoctorId);
        return mapper.Map<IEnumerable<AppointmentDto>>(appointments);
    }
}  