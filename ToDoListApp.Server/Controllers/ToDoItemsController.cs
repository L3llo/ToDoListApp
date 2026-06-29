using Microsoft.AspNetCore.Mvc;
using ToDoListApp.Server.Application.ToDoItems.DTOs;
using ToDoListApp.Server.Application.ToDoItems.Interfaces;

namespace ToDoListApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoItemsController(IToDoItemService service) : ControllerBase
    {
        private readonly IToDoItemService _service = service;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoItemDto>>> GetAll(CancellationToken cancellationToken)
        {
            var items = await _service.GetAllAsync(cancellationToken);
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoItemDto>> GetById(int id, CancellationToken cancellationToken)
        {
            var item = await _service.GetByIdAsync(id, cancellationToken);
            if (item is null)
                return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<ToDoItemDto>> Create(CreateToDoItemDto dto, CancellationToken cancellationToken)
        {
            var created = await _service.CreateAsync(dto, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ToDoItemDto>> Update(int id, UpdateToDoItemDto dto, CancellationToken cancellationToken)
        {
            var updated = await _service.UpdateAsync(id, dto, cancellationToken);
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            await _service.DeleteAsync(id, cancellationToken);
            return NoContent();
        }
    }
}
