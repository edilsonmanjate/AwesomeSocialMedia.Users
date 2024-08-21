using AwesomeSocialMedia.Application.Commands.SignUpUser;
using AwesomeSocialMedia.Application.Commands.UpdateUser;
using AwesomeSocialMedia.Application.Queries.GetUserById;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace AwesomeSocialMedia.Users.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : Controller
{
    private IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(Guid id)
    {
        var result = await _mediator.Send(new GetUserByIdQuery(id));

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post( SignUpUserCommand command)
    {
        var result = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetUserById), new { id = result.Data }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, UpdateUserCommand command)
    {
        command.Id = id;
        var result = await _mediator.Send(command);

        return Ok(result);
    }
}
