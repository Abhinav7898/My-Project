using CRUD.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUD.Dal
{
    public partial class CRUDDalBase
    {
        public DbSet<Registration> Registration { get; set; }
    }
    public class RegistrationConfiguration : IEntityTypeConfiguration<Registration>
    {
        public void Configure(EntityTypeBuilder<Registration> builder)
        {
            builder.ToTable(nameof(Registration));
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).HasMaxLength(100);
            builder.Property(x => x.Email).HasMaxLength(300);
            builder.Property(x => x.Password).HasMaxLength(100);
            builder.Property(x => x.PhoneNo).HasMaxLength(20);
        }
    }
}
