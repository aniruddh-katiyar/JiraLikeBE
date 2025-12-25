using JiraLike.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraLike.Infrastructure.Configurations
{
    public class TaskItemEntityConfiguration : IEntityTypeConfiguration<TaskItemEntity>
    {
        public void Configure(EntityTypeBuilder<TaskItemEntity> builder)
        {
            //Table name
            builder.ToTable("TaskItem");

            //Primary Key
            builder.HasKey(x => x.Id);

            //Reationship 1 Project -> M task
            builder.HasOne(x => x.Project).WithMany(p => p.Tasks)
                .HasForeignKey(x => x.ProjectId)
                 .OnDelete(DeleteBehavior.Cascade); 

            //Reationship 1 User -> M task
            builder.HasOne(task => task.AssignedUser).WithMany(user => user.AssignedTasks)
                .HasForeignKey(task => task.AssignedUserId)
                 .OnDelete(DeleteBehavior.Restrict);

            //Exclude Soft deleted Property
            builder.HasQueryFilter(task => !task.IsDeleted);
        }
    }
}
