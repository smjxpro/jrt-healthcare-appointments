using MediatR;

namespace Healthcare.Appointments.Application.Doctors.Commands;

public class DeleteDoctorCommand : IRequest
{
   public required Guid Id { get; set; }
}