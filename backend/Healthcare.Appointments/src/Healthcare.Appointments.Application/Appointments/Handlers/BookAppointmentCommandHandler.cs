using Healthcare.Appointments.Application.Appointments.Commands;
using Healthcare.Appointments.Application.Appointments.Dtos;
using Healthcare.Appointments.Application.Commons.Exceptions;
using Healthcare.Appointments.Domain.Contracts;
using MapsterMapper;
using MediatR;

namespace Healthcare.Appointments.Application.Appointments.Handlers;

public class BookAppointmentCommandHandler(IAppointmentRepository appointmentRepository, IMapper mapper)
    : IRequestHandler<BookAppointmentCommand, AppointmentDto>
{
    public async Task<AppointmentDto> Handle(BookAppointmentCommand request, CancellationToken cancellationToken)
    {
        if (request.BookAppointment.DateTime.ToUniversalTime()<DateTime.Now.AddHours(1).ToUniversalTime())
        {
            throw new BadRequestException("Appointment must be at least 1 hour in the future");
        }
        
        var existForDoctorInThisTime = await appointmentRepository.GetByDoctorIdAndDateTimeAsync(request.BookAppointment.DoctorId, request.BookAppointment.DateTime);
        if (existForDoctorInThisTime != null)
        {
            throw new BadRequestException("There is already an appointment for this doctor at this time");
        }
        
        var entity = mapper.Map<Domain.Entities.Appointment>(request.BookAppointment);
        entity.UserId = request.UserId;
        var appointment = await appointmentRepository.AddAsync(entity);
        return mapper.Map<AppointmentDto>(appointment);
    }
}