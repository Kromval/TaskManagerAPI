using Microsoft.EntityFrameworkCore;
using TaskManager.Data;
using TaskManager.Models;

namespace TaskManager.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly AppDbContext _context;

    private TaskRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<TaskItem>> GetAllAsync()
    {
        return await _context.TaskItems
            .Include(t => t.SubTasks)
            .ToListAsync();
    }

    public async Task<TaskItem?> GetByIdAsync(Guid id)
    {
        return await _context.TaskItems
            .Include(t => t.SubTasks)
            .FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task AddAsync(TaskItem task)
    {
        await _context.TaskItems.AddAsync(task);
    }
    
    public async Task UpdateAsync(TaskItem task)
    {
        _context.TaskItems.Update(task);
    }

    public async Task DeleteAsync(TaskItem task)
    {
        _context.TaskItems.Remove(task);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}