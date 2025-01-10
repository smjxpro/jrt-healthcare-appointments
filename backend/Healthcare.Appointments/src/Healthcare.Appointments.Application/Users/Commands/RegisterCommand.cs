using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Healthcare.Appointments.Application.Users.Commands;

public record RegisterCommand : IRequest
{
    [Required] public required string Name { get; set; }

    [Required] public required string UserName { get; set; }

    [Required] public required string Email { get; set; }

    [Required]
    [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
    public required string Password { get; set; }
}