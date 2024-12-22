using Microsoft.EntityFrameworkCore;
using TaskManagerServiceASP.Core.Abstractions;
using TaskManagerServiceASP.Core.Model;
using TaskManagerServiceASP.DataAccess.Entity;

namespace TaskManagerServiceASP.DataAccess.Repository;

public class TaskRepository(TaskManagerDbContext context) : ITaskRepository
{
    public async Task<List<TaskModel>> Get()
    {
        var taskEntities = await context.Tasks
            .AsNoTracking()
            .ToListAsync();

        var tasks = taskEntities.Select(
                t => new TaskModel(t.Id, t.Description, t.Title, t.Level)
            )
            .ToList();
        return tasks;
    }

    public async Task<TaskModel> Create(TaskModel task)
    {
        var taskEntity = new TaskEntity
        {
            Id = task.Id,
            Description = task.Description,
            Title = task.Title,
            Level = task.Level
        };

        await context.Tasks.AddAsync(taskEntity);

        return task;
    }

    public async Task<TaskModel> Update(TaskModel task)
    {
        await context.Tasks
            .Where(t => t.Id == task.Id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(b => b.Title, task.Title)
                .SetProperty(b => b.Description, task.Description)
                .SetProperty(b => b.Level, task.Level)
                .SetProperty(b => b.Status, task.Status)
            );
        return task;
    }

    public async Task<Guid> Delete(Guid id)
    {
        await context.Tasks
            .Where(t => t.Id == id)
            .ExecuteDeleteAsync();
        return id;
    }
}