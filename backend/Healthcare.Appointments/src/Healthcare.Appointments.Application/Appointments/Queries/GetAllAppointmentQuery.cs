using Healthcare.Appointments.Application.Appointments.Dtos;
using MediatR;

namespace Healthcare.Appointments.Application.Appointments.Queries;

public record GetAllAppointmentQuery(int Page = 1, int PageSize = 10, string? Search = null, DateOnly? Date = null, Guid? DoctorId = null, Guid? UserId = null): IRequest<IEnumerable<AppointmentDto>>{
    public Guid? UserId { get; set; }
}