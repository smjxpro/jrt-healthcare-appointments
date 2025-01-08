using Healthcare.Appointments.Application.Commons.Exceptions;
using Healthcare.Appointments.Application.Users.Commands;
using Healthcare.Appointments.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Healthcare.Appointments.Application.Users.Handlers;

public class RegisterCommandHandler(UserManager<User> userManager) : IRequestHandler<RegisterCommand>
{
    public async Task Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var result = await userManager.CreateAsync(new User
        {
            Name = request.Name,
            Email = request.Email,
            UserName = request.UserName,
        }, request.Password);

        if (!result.Succeeded)
        {
            throw new BadRequestException(result.Errors.First().Description);
        }
    }
}