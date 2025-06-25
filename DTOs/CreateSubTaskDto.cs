using System.ComponentModel.DataAnnotations;

namespace TaskManager.DTOs;

public class CreateSubTaskDto
{
    [Required] public string Title { get; set; } = "";
}