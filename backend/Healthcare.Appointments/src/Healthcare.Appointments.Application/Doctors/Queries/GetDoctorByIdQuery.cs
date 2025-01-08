using Healthcare.Appointments.Application.Doctors.Dtos;
using MediatR;

namespace Healthcare.Appointments.Application.Doctors.Queries;

public class GetDoctorByIdQuery : IRequest<DoctorDto>
{
    public required Guid Id { get; set; }
}