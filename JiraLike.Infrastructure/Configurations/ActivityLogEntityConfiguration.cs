using JiraLike.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace JiraLike.Infrastructure.Configurations
{
    public class ActivityLogEntityConfiguration : IEntityTypeConfiguration<ActivityLogEntity>
    {
       public void Configure(EntityTypeBuilder<ActivityLogEntity> builder)
        {
            //Table
            builder.ToTable("ActivityLogs");

            builder.HasKey(activityLog => activityLog.Id);

            builder.HasQueryFilter(activityLog => !activityLog.IsDeleted);
        }
    }
}
