using TaskManager.DTOs;

namespace TaskManager.Services;

public interface ITaskService
{
    Task<List<TaskViewDto>> GetAllAsync();
    Task<TaskViewDto?> GetByIdAsync(Guid id);
    Task<TaskViewDto> CreateAsync(CreateTaskDto dto);
    Task<bool> UpdateAsync(Guid id ,UpdateTaskDto dto);
    Task<bool> DeleteAsync(Guid id);
}