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
        public async Task<ActionResult<IEnumerable<ToDoItemDto>>> GetAll()
        {
            var items = await _service.GetAllAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoItemDto>> GetById(int id)
        {
            var item = await _service.GetByIdAsync(id);
            if (item is null)
                return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<ToDoItemDto>> Create(CreateToDoItemDto dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ToDoItemDto>> Update(int id, UpdateToDoItemDto dto)
        {
            try
            {
                var updated = await _service.UpdateAsync(id, dto);
                return Ok(updated);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _service.DeleteAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
