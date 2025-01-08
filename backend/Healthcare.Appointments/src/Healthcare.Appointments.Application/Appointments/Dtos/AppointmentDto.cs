namespace Healthcare.Appointments.Application.Appointments.Dtos;

public record AppointmentDto(
    Guid Id,
    Guid UserId,
    string PatientName,
    string PatientContactInformation,
    Guid DoctorId,
    string DoctorName,
    DateTimeOffset DateTime);