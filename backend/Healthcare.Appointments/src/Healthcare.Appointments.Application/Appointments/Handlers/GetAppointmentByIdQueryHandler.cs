using Healthcare.Appointments.Application.Appointments.Dtos;
using Healthcare.Appointments.Application.Appointments.Queries;
using Healthcare.Appointments.Application.Commons.Exceptions;
using Healthcare.Appointments.Domain.Contracts;
using MapsterMapper;
using MediatR;

namespace Healthcare.Appointments.Application.Appointments.Handlers;

public class GetAppointmentByIdQueryHandler(IAppointmentRepository appointmentRepository, IMapper mapper)
    : IRequestHandler<GetAppointmentByIdQuery, AppointmentDto>
{
    public async Task<AppointmentDto> Handle(GetAppointmentByIdQuery request, CancellationToken cancellationToken)
    {
        var appointment = await appointmentRepository.GetByIdAsync(request.Id);

        if (appointment == null)
        {
            throw new NotFoundException("Appointment not found");
        }

        return mapper.Map<AppointmentDto>(appointment);
    }
}