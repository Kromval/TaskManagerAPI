using TaskManager.Models;

namespace TaskManager.DTOs;

public class TaskViewDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = "";
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? DueDate { get; set; }
    public bool IsCompleted { get; set; }
    public string Recurrence { get; set; } = "None";
    
    public List<SubTaskDto> SubTasks { get; set; } = new();
}