using CRUD.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUD.Dal
{
    public partial class CRUDDalBase
    {
        public DbSet<Tasks> Tasks { get; set; }
    }
    public class TasksConfiguration : IEntityTypeConfiguration<Tasks>
    {
        public void Configure(EntityTypeBuilder<Tasks> builder)
        {
            builder.ToTable(nameof(Tasks));
            builder.Property(x => x.TaskId).UseSequence();
            builder.HasKey(x=> new { x.TaskUserId, x.TaskId });
            builder.Property(x => x.TaskName).HasMaxLength(256);
        }
    }
}
