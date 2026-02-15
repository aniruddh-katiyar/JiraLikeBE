using JiraLike.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace JiraLike.Infrastructure.Configurations
{
    public class ActivityLogEntityConfiguration : IEntityTypeConfiguration<ActivityLogEntity>
    {
        public void Configure(EntityTypeBuilder<ActivityLogEntity> builder)
        {
            builder.ToTable("ActivityLogs");

            builder.HasKey(a => a.Id);

            builder.HasOne(c => c.Project)
                 .WithMany()
                 .HasForeignKey(c => c.ProjectId);

            builder.Property(a => a.EntityType).HasConversion<string>();

            builder.HasQueryFilter(a => !a.IsDeleted);
        }
    }

}
