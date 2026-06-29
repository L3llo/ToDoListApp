using Microsoft.AspNetCore.Mvc;
using ToDoListApp.Server.Application.ToDoItems.DTOs;
using ToDoListApp.Server.Application.ToDoItems.Interfaces;

namespace ToDoListApp.Server.Controllers
{
    /// <summary>Manages to-do items via CRUD endpoints.</summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoItemsController(IToDoItemService service) : ControllerBase
    {
        private readonly IToDoItemService _service = service;

        /// <summary>Returns all to-do items.</summary>
        [HttpGet]
        [ProducesResponseType<IEnumerable<ToDoItemDto>>(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ToDoItemDto>>> GetAll(CancellationToken cancellationToken)
        {
            var items = await _service.GetAllAsync(cancellationToken);
            return Ok(items);
        }

        /// <summary>Returns a single to-do item by ID.</summary>
        /// <param name="id">The ID of the to-do item.</param>
        /// <param name="cancellationToken"></param>
        [HttpGet("{id}")]
        [ProducesResponseType<ToDoItemDto>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ToDoItemDto>> GetById(int id, CancellationToken cancellationToken)
        {
            var item = await _service.GetByIdAsync(id, cancellationToken);
            if (item is null)
                return NotFound();
            return Ok(item);
        }

        /// <summary>Creates a new to-do item.</summary>
        /// <param name="dto">Title and (optional) description of the new item.</param>
        /// <param name="cancellationToken"></param>
        [HttpPost]
        [ProducesResponseType<ToDoItemDto>(StatusCodes.Status201Created)]
        public async Task<ActionResult<ToDoItemDto>> Create(CreateToDoItemDto dto, CancellationToken cancellationToken)
        {
            var created = await _service.CreateAsync(dto, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        /// <summary>Updates title, description, and state of an existing to-do item.</summary>
        /// <param name="id">The ID of the item to update.</param>
        /// <param name="dto">Updated fields.</param>
        /// <param name="cancellationToken"></param>
        [HttpPut("{id}")]
        [ProducesResponseType<ToDoItemDto>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ToDoItemDto>> Update(int id, UpdateToDoItemDto dto, CancellationToken cancellationToken)
        {
            var updated = await _service.UpdateAsync(id, dto, cancellationToken);
            return Ok(updated);
        }

        /// <summary>Deletes a to-do item by ID.</summary>
        /// <param name="id">The ID of the item to delete.</param>
        /// <param name="cancellationToken"></param>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            await _service.DeleteAsync(id, cancellationToken);
            return NoContent();
        }
    }
}
