using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.Models;

public class TaskItem
{
    [Key]
    public Guid Id { get; set; }
    [Required] 
    public string Title { get; set; } = "";
    
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? DueDate { get; set; }
    public bool IsCompleted { get; set; } = false;
    public RecurrenceType Recurrence { get; set; } = RecurrenceType.None;

    public ICollection<SubTask> SubTasks { get; set; } = new List<SubTask>();
}