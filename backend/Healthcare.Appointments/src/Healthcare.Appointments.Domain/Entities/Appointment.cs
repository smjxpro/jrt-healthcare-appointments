namespace Healthcare.Appointments.Domain.Entities;

public class Appointment
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
    public string PatientName { get; set; }
    public string PatientContactInformation { get; set; }
    public Guid DoctorId { get; set; }
    public Doctor Doctor { get; set; }
    public DateTimeOffset DateTime { get; set; }
}