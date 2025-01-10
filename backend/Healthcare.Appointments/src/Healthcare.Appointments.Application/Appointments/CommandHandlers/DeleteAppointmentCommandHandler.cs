using Healthcare.Appointments.Application.Appointments.Commands;
using Healthcare.Appointments.Application.Commons.Exceptions;
using Healthcare.Appointments.Domain.Contracts;
using MediatR;

namespace Healthcare.Appointments.Application.Appointments.CommandHandlers;

public class DeleteAppointmentCommandHandler(IAppointmentRepository appointmentRepository)
    : IRequestHandler<DeleteAppointmentCommand>
{
    public async Task Handle(DeleteAppointmentCommand request, CancellationToken cancellationToken)
    {
        var appointment = await appointmentRepository.GetByIdAsync(request.Id, cancellationToken) ?? throw new NotFoundException("Appointment not found");
        await appointmentRepository.DeleteAsync(appointment, cancellationToken);
    }
}