using Healthcare.Appointments.Application.Doctors.Dtos;
using MediatR;

namespace Healthcare.Appointments.Application.Doctors.Queries;

public class GetAllDoctorQuery:IRequest<IEnumerable<DoctorDto>>;