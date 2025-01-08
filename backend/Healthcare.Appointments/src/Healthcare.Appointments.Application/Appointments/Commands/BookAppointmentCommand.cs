using Healthcare.Appointments.Application.Appointments.Dtos;
using MediatR;

namespace Healthcare.Appointments.Application.Appointments.Commands;

public record BookAppointmentCommand(Guid UserId, BookAppointmentDto BookAppointment) : IRequest<AppointmentDto>;