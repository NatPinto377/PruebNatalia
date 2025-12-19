using MediatR;
using Microsoft.AspNetCore.Mvc;
using RedArbor.Application.Commands.CreateEmployee;

namespace RedArbor.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RedarborController : ControllerBase
{
    private readonly IMediator mediator;

    public RedarborController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    // GET /api/redarbor
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await mediator.Send(new GetAllEmployeesQuery());
        return Ok(result);
    }

    // GET /api/redarbor/{id}
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await mediator.Send(new GetEmployeeByIdQuery(id));
        if (result == null) return NotFound();
        return Ok(result);
    }

    // POST /api/redarbor
    [HttpPost]
    public async Task<IActionResult> Create(CreateEmployeeCommand command)
    {
        var id = await mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id }, null);
    }

    // PUT /api/redarbor/{id}
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateEmployeeCommand command)
    {
        if (id != command.Id) return BadRequest();
        await mediator.Send(command);
        return NoContent();
    }

    // DELETE /api/redarbor/{id}
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await mediator.Send(new DeleteEmployeeCommand(id));
        return NoContent();
    }
}



