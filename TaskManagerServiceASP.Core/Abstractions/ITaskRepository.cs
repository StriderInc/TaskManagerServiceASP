using TaskManagerServiceASP.Core.Model;

namespace TaskManagerServiceASP.Core.Abstractions;

public interface ITaskRepository
{
    Task<List<TaskModel>> Get();
    Task<TaskModel> Create(TaskModel task);
    Task<TaskModel> Update(TaskModel task);
    Task<Guid> Delete(Guid id);
}