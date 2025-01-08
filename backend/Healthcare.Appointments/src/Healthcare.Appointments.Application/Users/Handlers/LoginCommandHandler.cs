using Healthcare.Appointments.Application.Commons.Exceptions;
using Healthcare.Appointments.Application.Users.Commands;
using Healthcare.Appointments.Application.Users.Dtos;
using Healthcare.Appointments.Domain.Contracts;
using Healthcare.Appointments.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Healthcare.Appointments.Application.Users.Handlers;

public class LoginCommandHandler(UserManager<User> userManager, IUserRepository userRepository)
    : IRequestHandler<LoginCommand, TokenDto>
{
    public async Task<TokenDto> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.Users.FirstOrDefaultAsync(x=> x.UserName == request.UserName, cancellationToken);

        if (user == null)
        {
            throw new BadRequestException("User or password is incorrect");
        }

        var result = await userManager.CheckPasswordAsync(user, request.Password);

        if (!result)
        {
            throw new BadRequestException("User or password is incorrect");
        }

        var token = userRepository.GetTokenAsync(user);

        return new TokenDto(token);
    }
}