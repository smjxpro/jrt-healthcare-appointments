using System.ComponentModel.DataAnnotations;
using Healthcare.Appointments.Application.Appointments.Dtos;
using MediatR;

namespace Healthcare.Appointments.Application.Appointments.Commands;

public class UpdateAppointmentCommand : IRequest<AppointmentDto>
{
    public required Guid Id { get; set; }
    public required Guid UserId { get; set; }

    [MinLength(6, ErrorMessage = "The patient name must be at least 6 characters long")]
    public required string PatientName { get; set; }

    public required string PatientContactInformation { get; set; }
    public required Guid DoctorId { get; set; }
    public required DateTimeOffset DateTime { get; set; }
}