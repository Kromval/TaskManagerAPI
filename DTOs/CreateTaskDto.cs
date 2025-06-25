using System.ComponentModel.DataAnnotations;
using TaskManager.Models;

namespace TaskManager.DTOs;

public class CreateTaskDto
{
    [Required] public string Title { get; set; } = "";
    public string? Description { get; set; }
    public DateTime? DueDate { get; set; }
    public RecurrenceType Recurrence { get; set; } = RecurrenceType.None;
    public List<CreateSubTaskDto>? SubTasks { get; set; } 
}