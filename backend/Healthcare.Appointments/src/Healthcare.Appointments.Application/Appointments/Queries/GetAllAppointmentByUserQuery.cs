using Healthcare.Appointments.Application.Appointments.Dtos;
using MediatR;

namespace Healthcare.Appointments.Application.Appointments.Queries;

public class GetAllAppointmentByUserQuery : IRequest<IEnumerable<AppointmentDto>>
{
    public required Guid UserId { get; set; }
}