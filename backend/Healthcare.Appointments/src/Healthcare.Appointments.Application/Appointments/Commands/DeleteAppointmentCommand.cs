using MediatR;

namespace Healthcare.Appointments.Application.Appointments.Commands;

public class DeleteAppointmentCommand: IRequest
{
    public required Guid Id { get; set; }
}