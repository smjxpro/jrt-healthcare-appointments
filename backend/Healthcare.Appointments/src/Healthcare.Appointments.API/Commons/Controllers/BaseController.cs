using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Healthcare.Appointments.API.Commons.Controllers;

[ApiController]
[Route("[controller]")]
public class BaseController(IMediator mediator) : ControllerBase
{
    protected readonly IMediator Mediator = mediator;
}