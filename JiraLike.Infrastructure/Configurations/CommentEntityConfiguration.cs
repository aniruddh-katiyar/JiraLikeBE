using JiraLike.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace JiraLike.Infrastructure.Configurations
{
    public class CommentEntityConfiguration : IEntityTypeConfiguration<CommentEntity>
    {
   
        public void Configure(EntityTypeBuilder<CommentEntity> builder)
        {
            //Set Table Name
            builder.ToTable("Comments");

            //Set Primary Key
            builder.HasKey(comment => comment.Id);

            //Navigation
            builder.HasOne(comment => comment.TaskItem)
                .WithMany(taskItem => taskItem.Comments)
                .HasForeignKey(comment => comment.TaskItemId)
                .OnDelete(DeleteBehavior.Cascade); 

            //Navigation
            builder.HasOne(comment => comment.User)
                .WithMany(user => user.Comments)
                .HasForeignKey(comment => comment.UserId)
                 .OnDelete(DeleteBehavior.Restrict);


            //Soft Delete
            builder.HasQueryFilter(comment => !comment.IsDeleted);
        }
    }
}
