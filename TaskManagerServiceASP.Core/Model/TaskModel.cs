using TaskManagerServiceASP.Core.Enum;

namespace TaskManagerServiceASP.Core.Model;

public class TaskModel(
    Guid id,
    string title,
    string description,
    TaskLevel taskLevel = TaskLevel.Easy
)
{
    public const byte MAX_TITLE_LENGTH = 250;
    
    public Guid Id { get; } = id;
    public string Title { get; } = title;
    public string Description { get; } = description;

    public TaskState Status { get; } = TaskState.IsRegistered;
    public TaskLevel Level { get; } = taskLevel;
}