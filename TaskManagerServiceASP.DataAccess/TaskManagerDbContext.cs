using Microsoft.EntityFrameworkCore;
using TaskManagerServiceASP.DataAccess.Entity;

namespace TaskManagerServiceASP.DataAccess;

public class TaskManagerDbContext: DbContext
{
    public TaskManagerDbContext(DbContextOptions<TaskManagerDbContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }
    
    public DbSet<TaskEntity> Tasks { get; set; }
}