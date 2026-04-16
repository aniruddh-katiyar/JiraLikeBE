namespace JiraLike.Infrastructure.Repositories
{
    using JiraLike.Infrastructure.DbContexts;

    public class CommentRepository 
    {
        private readonly JiraLikeDbContext _jiraLikeDbContext;
        public CommentRepository(JiraLikeDbContext jiraLikeDbContext)
        {
            _jiraLikeDbContext = jiraLikeDbContext;
        }


    }
}
