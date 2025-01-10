using Healthcare.Appointments.Application.Doctors.Dtos;
using MediatR;

namespace Healthcare.Appointments.Application.Doctors.Queries;

public record GetAllDoctorQuery(int Page = 1, int PageSize = 10, string? Search = null) : IRequest<IEnumerable<DoctorDto>>;