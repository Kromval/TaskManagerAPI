using TaskManager.Models;

namespace TaskManager.Repositories;

public interface ITaskRepository
{
    Task<List<TaskItem>> GetAllAsync();
    Task<TaskItem?> GetByIdAsync(Guid id);
    Task AddAsync(TaskItem task);
    Task UpdateAsync(TaskItem task);
    Task DeleteAsync(TaskItem task);
    Task SaveChangesAsync();
    Task<List<TaskItem>> GetFilteredAsync(string? search, bool? isCompleted, string? sortField, bool descending);

}