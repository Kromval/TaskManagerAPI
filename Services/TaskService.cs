using TaskManager.Models;
using TaskManager.DTOs;
using TaskManager.Mappers;
using TaskManager.Repositories;

namespace TaskManager.Services;

public class TaskService : ITaskService
{
    private readonly ITaskRepository _repo;

    public TaskService(ITaskRepository repo)
    {
        _repo = repo;
    }

    public async Task<List<TaskViewDto>> GetAllAsync()
    {
        var tasks = await _repo.GetAllAsync();
        return tasks.Select(TaskMapper.ToTaskViewDto).ToList();
    }

    public async Task<TaskViewDto?> GetByIdAsync(Guid id)
    {
        var task = await _repo.GetByIdAsync(id);
        return task == null ? null : TaskMapper.ToTaskViewDto(task);
    }

    public async Task<TaskViewDto> CreateAsync(CreateTaskDto dto)
    {
        var task = TaskMapper.ToTaskItem(dto);
        await _repo.AddAsync(task);
        await _repo.SaveChangesAsync();
        return TaskMapper.ToTaskViewDto(task);
    }

    public async Task<bool> UpdateAsync(Guid id, UpdateTaskDto dto)
    {
        var task = await _repo.GetByIdAsync(id);
        if (task == null) return false;
        
        TaskMapper.UpdateTaskFromDto(task, dto);
        await _repo.UpdateAsync(task);
        await _repo.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var task = await _repo.GetByIdAsync(id);
        if (task == null) return false;
        
        await _repo.DeleteAsync(task);
        await _repo.SaveChangesAsync();
        return true;
    }
}