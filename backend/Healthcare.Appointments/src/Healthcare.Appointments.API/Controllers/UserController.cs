using Healthcare.Appointments.API.Commons.Controllers;
using Healthcare.Appointments.Application.Users.Commands;
using Healthcare.Appointments.Application.Users.Dtos;
using Healthcare.Appointments.Application.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Healthcare.Appointments.API.Controllers;

[AllowAnonymous]
public class UserController(IMediator mediator) : BaseController(mediator)
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetAll([FromQuery] GetAllUserQuery query)
    {
        var users = await Mediator.Send(query, cancellationToken: HttpContext.RequestAborted);
        return Ok(users);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterCommand registerCommand)
    {
        await Mediator.Send(registerCommand, cancellationToken: HttpContext.RequestAborted);
        return NoContent();
    }

    [HttpPost("login")]
    public async Task<ActionResult<TokenDto>> Login([FromBody] LoginCommand loginCommand)
    {
        var result = await Mediator.Send(loginCommand, cancellationToken: HttpContext.RequestAborted);
        return Ok(result);
    }
}