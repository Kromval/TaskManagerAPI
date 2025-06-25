using Microsoft.AspNetCore.Mvc;
using TaskManager.DTOs;
using TaskManager.Services;

namespace TaskManager.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
    private readonly ITaskService _service;

    public TaskController(ITaskService service)
    {
        _service = service;
    }
    
    // GET: api/tasks
    [HttpGet]
    public async Task<ActionResult<List<TaskViewDto>>> GetAll()
    {
        var tasks = await _service.GetAllAsync();
        return Ok(tasks);
    }
    
    // GET: api/tasks/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<TaskViewDto>> GetById(Guid id)
    {
        var task = await _service.GetByIdAsync(id);
        if(task == null)
            return NotFound();
        return Ok(task);
    }
    
    // POST: api/tasks
    [HttpPost]
    public async Task<ActionResult<TaskViewDto>> Create(CreateTaskDto dto)
    {
        var created = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }
    
    // PUT: api/tasks/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, UpdateTaskDto dto)
    {
        var result = await _service.UpdateAsync(id, dto);
        return result ? NoContent() : NotFound();
    }
    
    // DELETE: api/tasks/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _service.DeleteAsync(id);
        return result ? NoContent() : NotFound(); 
    }
    
    // GET: apic/tasks/{params}
    [HttpGet("filter")]
    public async Task<ActionResult<List<TaskViewDto>>> GetFiltered(
        [FromQuery] string? search,
        [FromQuery] bool? isCompleted,
        [FromQuery] string? sort,
        [FromQuery] bool desc = false)
    {
        var tasks = await _service.GetFilteredAsync(search, isCompleted, sort, desc);
        return Ok(tasks);
    }

} 