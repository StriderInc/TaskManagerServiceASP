using Microsoft.EntityFrameworkCore;
using TaskManagerServiceASP.Core.Model;

namespace TaskManagerServiceASP.DataAccess;

public class TaskManagerDbContext: DbContext
{
    public TaskManagerDbContext(DbContextOptions<TaskManagerDbContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }
    
    public DbSet<TaskModel> Tasks { get; set; }
}