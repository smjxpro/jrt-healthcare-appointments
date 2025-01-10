using Healthcare.Appointments.Application.Appointments.Dtos;
using MediatR;

namespace Healthcare.Appointments.Application.Appointments.Queries;

public record GetAppointmentByIdQuery(Guid Id): IRequest<AppointmentDto>;