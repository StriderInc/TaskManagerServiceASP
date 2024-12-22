using TaskManagerServiceASP.Core.Enum;

namespace TaskManagerServiceASP.DataAccess.Entity;

public class TaskEntity
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public TaskState Status { get; set; }
    public TaskLevel Level { get; set; }
}