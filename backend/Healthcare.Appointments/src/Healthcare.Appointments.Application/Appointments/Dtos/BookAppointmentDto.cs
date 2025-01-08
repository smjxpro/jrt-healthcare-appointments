using System.ComponentModel.DataAnnotations;

namespace Healthcare.Appointments.Application.Appointments.Dtos;

public record BookAppointmentDto
{
    [MinLength(6, ErrorMessage = "The patient name must be at least 6 characters long")]
    public required string PatientName { get; set; }

    public required string PatientContactInformation { get; set; }
    public required Guid DoctorId { get; set; }
    public required DateTimeOffset DateTime { get; set; }
}