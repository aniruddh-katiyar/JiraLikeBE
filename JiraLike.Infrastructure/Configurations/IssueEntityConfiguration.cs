using JiraLike.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JiraLike.Infrastructure.Configurations
{
    public class IssueEntityConfiguration : IEntityTypeConfiguration<IssueEntity>
    {
        public void Configure(EntityTypeBuilder<IssueEntity> builder)
        {
            builder.ToTable("Issues");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.Title).IsRequired();

            builder.Property(i => i.Type).HasConversion<string>().
                IsRequired();

            builder.Property(i => i.Status).HasConversion<string>().IsRequired();

            builder.Property(i => i.Priority).HasConversion<string>().IsRequired();

            builder.HasOne(i => i.Project)
                   .WithMany(p => p.Issues)
                   .HasForeignKey(i => i.ProjectId);

            builder.HasOne(i => i.ParentIssue)
                   .WithMany()
                   .HasForeignKey(i => i.ParentIssueId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(i => i.Assignee)
                   .WithMany()
                   .HasForeignKey(i => i.AssigneeId)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(i => i.Reporter)
                   .WithMany()
                   .HasForeignKey(i => i.ReporterId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasQueryFilter(i => !i.IsDeleted);
        }
    }
}
