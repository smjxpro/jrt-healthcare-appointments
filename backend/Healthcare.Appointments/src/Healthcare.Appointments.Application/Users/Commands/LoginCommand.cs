using System.ComponentModel.DataAnnotations;
using Healthcare.Appointments.Application.Users.Dtos;
using MediatR;

namespace Healthcare.Appointments.Application.Users.Commands;

public record LoginCommand: IRequest<TokenDto>
{
    [Required]
    public required string UserName { get; set; }
    [Required]
    public required string Password { get; set; }
}