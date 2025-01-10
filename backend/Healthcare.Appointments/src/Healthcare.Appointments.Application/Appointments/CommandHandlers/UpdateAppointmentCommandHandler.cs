using Healthcare.Appointments.Application.Appointments.Commands;
using Healthcare.Appointments.Application.Appointments.Dtos;
using Healthcare.Appointments.Application.Commons.Exceptions;
using Healthcare.Appointments.Domain.Contracts;
using MapsterMapper;
using MediatR;

namespace Healthcare.Appointments.Application.Appointments.CommandHandlers;

public class UpdateAppointmentCommandHandler(IAppointmentRepository appointmentRepository, IMapper mapper) : IRequestHandler<UpdateAppointmentCommand, AppointmentDto>
{
    public async Task<AppointmentDto> Handle(UpdateAppointmentCommand request, CancellationToken cancellationToken)
    {
        var appointment = await appointmentRepository.GetByIdAsync(request.Id, cancellationToken) ?? throw new NotFoundException("Appointment not found");
        mapper.Map(request, appointment);
        var updatedAppointment = await appointmentRepository.UpdateAsync(appointment, cancellationToken);
        return mapper.Map<AppointmentDto>(updatedAppointment);
    }
}