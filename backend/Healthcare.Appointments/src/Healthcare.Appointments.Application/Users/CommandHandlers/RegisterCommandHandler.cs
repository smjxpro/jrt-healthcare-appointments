using Healthcare.Appointments.Application.Commons.Exceptions;
using Healthcare.Appointments.Application.Users.Commands;
using Healthcare.Appointments.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Healthcare.Appointments.Application.Users.CommandHandlers;

public class RegisterCommandHandler(UserManager<User> userManager) : IRequestHandler<RegisterCommand>
{
    public async Task Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            Name = request.Name,
            Email = request.Email,
            UserName = request.UserName,
        };

        var result = await userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
        {
            throw new BadRequestException(result.Errors.First().Description);
        }

        var roleAddResult = await userManager.AddToRoleAsync(user, "User");

        if (!roleAddResult.Succeeded)
        {
            throw new BadRequestException(roleAddResult.Errors.First().Description);
        }
    }
}