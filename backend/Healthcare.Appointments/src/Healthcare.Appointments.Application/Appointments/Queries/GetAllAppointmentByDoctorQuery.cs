using Healthcare.Appointments.Application.Appointments.Dtos;
using MediatR;

namespace Healthcare.Appointments.Application.Appointments.Queries;

public class GetAllAppointmentByDoctorQuery: IRequest<IEnumerable<AppointmentDto>>
{
    public Guid DoctorId { get; set; }
}