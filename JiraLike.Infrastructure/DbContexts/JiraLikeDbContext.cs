using JiraLike.Domain.Entities;
using JiraLike.Domain.Token;
using JiraLike.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace JiraLike.Infrastructure.DbContexts
{
    public class JiraLikeDbContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<ActivityLogEntity> ActivityLogs { get; set; }
        public DbSet<ProjectEntity> Projects { get; set; }
        public DbSet<TaskItemEntity> Tasks { get; set; }
        public DbSet<CommentEntity> Comments { get; set; }
        public DbSet<RefreshTokenEntity> RefreshTokens { get; set; }   
        public DbSet<ProjectUserEntity> ProjectUsers { get; set; }

        public JiraLikeDbContext(DbContextOptions<JiraLikeDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Apply all configurations in this assembly
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(JiraLikeDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}