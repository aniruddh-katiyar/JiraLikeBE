using Microsoft.EntityFrameworkCore;

namespace JiraLike.Infrastructure.DbContexts
{
    public class JiraLikeDbContext : DbContext
    {
        public JiraLikeDbContext(DbContextOptions<JiraLikeDbContext> options) 
            : base(options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
