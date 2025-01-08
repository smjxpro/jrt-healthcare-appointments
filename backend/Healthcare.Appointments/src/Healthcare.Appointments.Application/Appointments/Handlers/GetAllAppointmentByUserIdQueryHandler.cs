using Healthcare.Appointments.Application.Appointments.Dtos;
using Healthcare.Appointments.Application.Appointments.Queries;
using Healthcare.Appointments.Domain.Contracts;
using MapsterMapper;
using MediatR;

namespace Healthcare.Appointments.Application.Appointments.Handlers;

public class GetAllAppointmentByUserIdQueryHandler(IAppointmentRepository appointmentRepository, IMapper mapper): IRequestHandler<GetAllAppointmentByUserQuery, IEnumerable<AppointmentDto>>
{
    public async Task<IEnumerable<AppointmentDto>> Handle(GetAllAppointmentByUserQuery request, CancellationToken cancellationToken)
    {
        var appointments = await appointmentRepository.GetByUserIdAsync(request.UserId);
        return mapper.Map<IEnumerable<AppointmentDto>>(appointments);
    }
}