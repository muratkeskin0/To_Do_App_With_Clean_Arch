using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Application.Commands.CreateToDoItemCommand;
using ToDoApp.Application.Commands.DeleteToDoItemCommand;
using ToDoApp.Application.Commands.UpdateToDoItemCommand;
using ToDoApp.Application.Queries.GetAllToDoItemsQuery;
using ToDoApp.Application.Queries.GetToDoItemByIdQuery;

namespace ToDoApp.Api.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoItemsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ToDoItemsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/todoitems
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllToDoItemsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // GET: api/todoitems/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetToDoItemByIdQuery(id);
            var result = await _mediator.Send(query);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // POST: api/todoitems
        [HttpPost]
        public async Task<IActionResult> Create(CreateToDoItemCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        // PUT: api/todoitems/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateToDoItemCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("ID mismatch");
            }

            var result = await _mediator.Send(command);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // DELETE: api/todoitems/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteToDoItemCommand(id);
            var result = await _mediator.Send(command);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
