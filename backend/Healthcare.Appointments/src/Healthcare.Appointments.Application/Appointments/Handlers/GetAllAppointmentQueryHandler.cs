using Healthcare.Appointments.Application.Appointments.Dtos;
using Healthcare.Appointments.Application.Appointments.Queries;
using Healthcare.Appointments.Domain.Contracts;
using MapsterMapper;
using MediatR;

namespace Healthcare.Appointments.Application.Appointments.Handlers;

public class GetAllAppointmentQueryHandler(IAppointmentRepository appointmentRepository, IMapper mapper): IRequestHandler<GetAllAppointmentQuery, IEnumerable<AppointmentDto>>
{
    public async Task<IEnumerable<AppointmentDto>> Handle(GetAllAppointmentQuery request, CancellationToken cancellationToken)
    {
        var appointments = await appointmentRepository.GetAllAsync();
        return mapper.Map<IEnumerable<AppointmentDto>>(appointments);
    }
}