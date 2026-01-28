namespace JiraLike.Application.Resolvers
{
    using JiraLike.Application.Models;
    using System.Threading.Tasks;

    public interface IUserInformationResolver
    {
        Task<UserInfo> GetUserInformation();
    }
}
