using JiraLike.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JiraLike.Infrastructure.Configurations
{
    public class ProjectUserEntityConfiguration : IEntityTypeConfiguration<ProjectUserEntity>
    {
       
       public void Configure(EntityTypeBuilder<ProjectUserEntity> builder)
        {
            builder.ToTable("ProjectUsers");

            // Composite Primary Key
            builder.HasKey(pu => new { pu.ProjectId, pu.UserId });

            // FK → Project
            builder.HasOne(pu => pu.Project)
                .WithMany(p => p.ProjectUsers)
                .HasForeignKey(pu => pu.ProjectId);

            // FK → User
            builder.HasOne(pu => pu.User)
                .WithMany(u => u.ProjectUsers)
                .HasForeignKey(pu => pu.UserId);

           builder.HasQueryFilter(pu => !pu.Project.IsDeleted);

        }
    }
}
