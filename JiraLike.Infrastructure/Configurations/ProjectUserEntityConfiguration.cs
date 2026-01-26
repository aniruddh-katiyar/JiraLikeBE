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

            builder.HasKey(pu => pu.Id);

            builder.HasOne(pu => pu.Project)
                   .WithMany(p => p.ProjectUsers)
                   .HasForeignKey(pu => pu.ProjectId);

            builder.HasOne(pu => pu.User)
                   .WithMany(u => u.ProjectUsers)
                   .HasForeignKey(pu => pu.UserId);

            builder.HasOne(pu => pu.Role)
                   .WithMany(r => r.ProjectUsers)
                   .HasForeignKey(pu => pu.RoleId);

            builder.HasQueryFilter(pu => !pu.IsDeleted);
        }
    }
}
