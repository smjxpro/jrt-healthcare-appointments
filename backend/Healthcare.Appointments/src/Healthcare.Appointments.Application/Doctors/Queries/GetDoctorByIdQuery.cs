using Healthcare.Appointments.Application.Doctors.Dtos;
using MediatR;

namespace Healthcare.Appointments.Application.Doctors.Queries;

public record GetDoctorByIdQuery(Guid Id) : IRequest<DoctorDto>;