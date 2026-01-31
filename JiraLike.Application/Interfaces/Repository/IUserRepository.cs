namespace JiraLike.Application.Interfaces.Repository
{
    using System;
    using System.Threading.Tasks;

    public interface IUserRepository
    {
        Task<string> GetUserNameAsync(Guid userid, CancellationToken token);
    }
}
