using JiraLike.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JiraLike.Infrastructure.Configurations
{
    public class CommentEntityConfiguration : IEntityTypeConfiguration<CommentEntity>
    {
        public void Configure(EntityTypeBuilder<CommentEntity> builder)
        {
            builder.ToTable("Comments");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Content).IsRequired();

            builder.HasOne(c => c.Issue)
                   .WithMany(i => i.Comments)
                   .HasForeignKey(c => c.IssueId);

            builder.HasOne(c => c.User)
                   .WithMany()
                   .HasForeignKey(c => c.UserId);

            builder.HasQueryFilter(c => !c.IsDeleted);
        }
    }
}
