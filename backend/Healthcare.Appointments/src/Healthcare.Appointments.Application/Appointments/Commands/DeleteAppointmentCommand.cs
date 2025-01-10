using MediatR;

namespace Healthcare.Appointments.Application.Appointments.Commands;

public record DeleteAppointmentCommand(Guid Id): IRequest;
