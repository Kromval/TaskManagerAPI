using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.Models;

public class SubTask
{
    [Key] public Guid Id { get; set; }

    [Required] public string Title { get; set; } = "";
    
    public bool IsDone { get; set; } = false;
    
    [ForeignKey("TaskItem")]
    public Guid TaskItemId { get; set; }
    
    public TaskItem TaskItem { get; set; } = null!;
}