using Healthcare.Appointments.Application.Appointments.Commands;
using Healthcare.Appointments.Application.Appointments.Dtos;
using Healthcare.Appointments.Application.Commons.Exceptions;
using Healthcare.Appointments.Domain.Contracts;
using MapsterMapper;
using MediatR;

namespace Healthcare.Appointments.Application.Appointments.CommandHandlers;

public class BookAppointmentCommandHandler(IAppointmentRepository appointmentRepository, IDoctorRepository doctorRepository, IMapper mapper)
    : IRequestHandler<BookAppointmentCommand, AppointmentDto>
{
    public async Task<AppointmentDto> Handle(BookAppointmentCommand request, CancellationToken cancellationToken)
    {
        if (await doctorRepository.GetByIdAsync(request.BookAppointment.DoctorId, cancellationToken) == null)
        {
            throw new BadRequestException("Selected doctor is unavailable");
        }

        if (request.BookAppointment.DateTime.ToUniversalTime() < DateTime.Now.AddHours(1).ToUniversalTime())
        {
            throw new BadRequestException("Appointment must be at least 1 hour in the future");
        }

        var existForDoctorInThisTime = await appointmentRepository.GetByDoctorIdAndDateTimeAsync(request.BookAppointment.DoctorId, request.BookAppointment.DateTime, cancellationToken);
        if (existForDoctorInThisTime != null)
        {
            throw new BadRequestException("There is already an appointment for this doctor at this time");
        }

        var entity = mapper.Map<Domain.Entities.Appointment>(request.BookAppointment);
        entity.UserId = request.UserId;
        var appointment = await appointmentRepository.AddAsync(entity, cancellationToken);
        return mapper.Map<AppointmentDto>(appointment);
    }
}