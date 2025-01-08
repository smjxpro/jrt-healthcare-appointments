using Healthcare.Appointments.Application.Appointments.Dtos;
using MediatR;

namespace Healthcare.Appointments.Application.Appointments.Queries;

public class GetAllAppointmentQuery: IRequest<IEnumerable<AppointmentDto>>
{
    
}