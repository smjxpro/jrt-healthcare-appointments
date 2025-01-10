using Healthcare.Appointments.API.Commons.Controllers;
using Healthcare.Appointments.Application.Doctors.Commands;
using Healthcare.Appointments.Application.Doctors.Dtos;
using Healthcare.Appointments.Application.Doctors.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Healthcare.Appointments.API.Controllers;

[Authorize]
public class DoctorController(IMediator mediator) : BaseController(mediator)
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<DoctorDto>>> GetAll()
    {
        var doctors = await Mediator.Send(new GetAllDoctorQuery(), cancellationToken: HttpContext.RequestAborted);

        return Ok(doctors);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<DoctorDto>> GetById(Guid id)
    {
        var doctor = await Mediator.Send(new GetDoctorByIdQuery(id), cancellationToken: HttpContext.RequestAborted);

        return Ok(doctor);
    }

    [HttpPost]
    [Authorize(Policy = "Admin")]
    public async Task<ActionResult<DoctorDto>> Add([FromBody] AddDoctorCommand command)
    {
        var doctor = await Mediator.Send(command, cancellationToken: HttpContext.RequestAborted);
        return CreatedAtAction(nameof(GetById), new { id = doctor.Id }, doctor);
    }

    [HttpPut("{id:guid}")]
    [Authorize(Policy = "Admin")]
    public async Task<ActionResult<DoctorDto>> Update(Guid id, [FromBody] UpdateDoctorCommand command)
    {
        command.Id = id;
        var doctor = await Mediator.Send(command, cancellationToken: HttpContext.RequestAborted);
        return Ok(doctor);
    }

    [HttpDelete("{id:guid}")]
    [Authorize(Policy = "Admin")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await Mediator.Send(new DeleteDoctorCommand { Id = id }, cancellationToken: HttpContext.RequestAborted);
        return NoContent();
    }
}