using TaskManager.DTOs;
using TaskManager.Models;

namespace TaskManager.Mappers;

public class TaskMapper
{
    public static TaskItem ToTaskItem(CreateTaskDto dto)
    {
        return new TaskItem
        {
            Title = dto.Title,
            Description = dto.Description,
            DueDate = dto.DueDate,
            Recurrence = dto.Recurrence,
            SubTasks = dto.SubTasks?.Select(s => new SubTask
            {
                Title = s.Title
            }).ToList() ?? new List<SubTask>()
        };
    }
    
    public static TaskViewDto ToTaskViewDto(TaskItem task)
    {
        return new TaskViewDto
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description,
            CreatedAt = task.CreatedAt,
            DueDate = task.DueDate,
            IsCompleted = task.IsCompleted,
            Recurrence = task.Recurrence.ToString(),
            SubTasks = task.SubTasks.Select(s => new SubTaskDto
            {
                Id = s.Id,
                Title = s.Title,
                IsDone = s.IsDone
            }).ToList()
        };
    }
    
    public static void UpdateTaskFromDto(TaskItem task, UpdateTaskDto dto)
    {
        if (dto.Title != null) task.Title = dto.Title;
        if (dto.Description != null) task.Description = dto.Description;
        if (dto.DueDate.HasValue) task.DueDate = dto.DueDate;
        if (dto.IsCompleted.HasValue) task.IsCompleted = dto.IsCompleted.Value;
        if (dto.Recurrence.HasValue) task.Recurrence = dto.Recurrence.Value;
    }
}