using JiraLike.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JiraLike.Infrastructure.Configurations
{
    public class ProjectEntityConfiguration : IEntityTypeConfiguration<ProjectEntity>
    {
        public void Configure(EntityTypeBuilder<ProjectEntity> builder)
        {
            builder.ToTable("Projects");

            builder.HasKey(p => p.Id);

            builder.HasIndex(p => p.Key).IsUnique();

            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Key).IsRequired();

            builder.HasQueryFilter(p => !p.IsDeleted);
        }
    }
}
