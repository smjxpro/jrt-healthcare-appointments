using System.Security.Claims;
using Healthcare.Appointments.API.Commons.Controllers;
using Healthcare.Appointments.Application.Appointments.Commands;
using Healthcare.Appointments.Application.Appointments.Dtos;
using Healthcare.Appointments.Application.Appointments.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Healthcare.Appointments.API.Controllers;

[Authorize(Policy = "User")]
public class AppointmentController(IMediator mediator) : BaseController(mediator)
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppointmentDto>>> GetAll()
    {
        var appointments = await Mediator.Send(new GetAllAppointmentQuery(), cancellationToken: HttpContext.RequestAborted);
        return Ok(appointments);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<AppointmentDto>> GetById(Guid id)
    {
        var appointment = await Mediator.Send(new GetAppointmentByIdQuery { Id = id }, cancellationToken: HttpContext.RequestAborted);
        return Ok(appointment);
    }

    [HttpPost]
    public async Task<ActionResult<AppointmentDto>> Book([FromBody] BookAppointmentDto bookAppointment)
    {
        var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userIdString == null)
        {
            return Unauthorized();
        }
        var userId = Guid.Parse(userIdString);
        var appointment = await Mediator.Send(new BookAppointmentCommand(userId, bookAppointment), cancellationToken: HttpContext.RequestAborted);
        return CreatedAtAction(nameof(GetById), new { id = appointment.Id }, appointment);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<AppointmentDto>> Update(Guid id, [FromBody] UpdateAppointmentCommand command)
    {
        command.Id = id;
        var appointment = await Mediator.Send(command, cancellationToken: HttpContext.RequestAborted);
        return Ok(appointment);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await Mediator.Send(new DeleteAppointmentCommand { Id = id }, cancellationToken: HttpContext.RequestAborted);
        return NoContent();
    }

    [HttpGet("doctor/{id:guid}")]
    [Authorize(Policy = "Admin")]
    public async Task<ActionResult<IEnumerable<AppointmentDto>>> GetByDoctorId(Guid id)
    {
        var appointments = await Mediator.Send(new GetAllAppointmentByDoctorQuery { DoctorId = id }, cancellationToken: HttpContext.RequestAborted);
        return Ok(appointments);
    }

    [HttpGet("user/{id:guid}")]
    [Authorize(Policy = "Admin")]
    public async Task<ActionResult<IEnumerable<AppointmentDto>>> GetByUserId(Guid id)
    {
        var appointments = await Mediator.Send(new GetAllAppointmentByUserQuery { UserId = id }, cancellationToken: HttpContext.RequestAborted);
        return Ok(appointments);
    }
}