using CRUD.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUD.Dal
{
    public partial class CRUDDalBase
    {
        public DbSet<Feedback> Feedbacks { get; set; }
    }
    public class FeedbackConfiguration : IEntityTypeConfiguration<Feedback>
    {
        public void Configure(EntityTypeBuilder<Feedback> builder)
        {
            builder.ToTable(nameof(Feedback));
            builder.HasKey(x=>x.UserId);
            builder.Property(x => x.UserName).HasMaxLength(100);
            builder.Property(x => x.UserEmail).HasMaxLength(100);
        }
    }
}
