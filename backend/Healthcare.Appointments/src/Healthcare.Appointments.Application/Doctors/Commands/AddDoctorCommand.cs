using System.ComponentModel.DataAnnotations;
using Healthcare.Appointments.Application.Doctors.Dtos;
using MediatR;

namespace Healthcare.Appointments.Application.Doctors.Commands;

public class AddDoctorCommand : IRequest<DoctorDto>
{
    [Required]
    [MinLength(6, ErrorMessage = "Name must be at least 6 characters long")]
    public required string Name { get; set; }

    [Required] public required string Specialty { get; set; }
}