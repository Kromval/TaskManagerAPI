namespace TaskManager.DTOs;

public class SubTaskDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = "";
    public bool IsDone { get; set; }
}