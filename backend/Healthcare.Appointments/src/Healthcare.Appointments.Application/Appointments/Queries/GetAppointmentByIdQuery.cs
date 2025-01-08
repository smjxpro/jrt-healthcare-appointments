using Healthcare.Appointments.Application.Appointments.Dtos;
using MediatR;

namespace Healthcare.Appointments.Application.Appointments.Queries;

public class GetAppointmentByIdQuery: IRequest<AppointmentDto>
{
    public required Guid Id { get; set; }
}