using JiraLike.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JiraLike.Infrastructure.Configurations
{
    public class ProjectEntityConfiguration : IEntityTypeConfiguration<ProjectEntity>
    {
        public void Configure(EntityTypeBuilder<ProjectEntity> builder)
        {
            //Table Name 
            builder.ToTable("Projects");

            //Primary Key
            builder.HasKey(project => project.Id);

            //Soft delete
            builder.HasQueryFilter(project => !project.IsDeleted);
        }
    }
}
