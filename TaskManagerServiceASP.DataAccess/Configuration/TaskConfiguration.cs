using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagerServiceASP.Core.Model;
using TaskManagerServiceASP.DataAccess.Entity;

namespace TaskManagerServiceASP.DataAccess.Configuration;

public class TaskConfiguration: IEntityTypeConfiguration<TaskEntity>    
{
    public void Configure(EntityTypeBuilder<TaskEntity> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Title)
            .HasMaxLength(TaskModel.MAX_TITLE_LENGTH)
            .IsRequired();
    }
}