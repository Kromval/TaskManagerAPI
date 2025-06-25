using TaskManager.Models;

namespace TaskManager.DTOs;

public class UpdateTaskDto
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public DateTime? DueDate { get; set; }
    public bool? IsCompleted { get; set; }
    public RecurrenceType? Recurrence { get; set; }
}