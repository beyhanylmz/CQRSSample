using CqrsSample.Commands;
using CqrsSample.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CqrsSample.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{
    private readonly IMediator _mediator;
    public PersonController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreatePersonCommand request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }
    
    [HttpGet("GetAll")]
    public async Task<IActionResult> Get([FromQuery] GetAllPersonQuery request)
    {
        var allPersons = await _mediator.Send(request);
        return Ok(allPersons);
    }
 
    [HttpGet("GetById")]
    public async Task<IActionResult> Get([FromQuery] GetByIdPersonQuery request)
    {
        var person = await _mediator.Send(request);
        return Ok(person);
    }
}