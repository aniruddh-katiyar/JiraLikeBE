namespace JiraLike.Application.Resolvers
{
    using JiraLike.Application.Interfaces.Repository;
    using JiraLike.Application.Models;
    using Microsoft.AspNetCore.Http;
    using System.Security.Claims;
    using System.Threading.Tasks;



    public class UserInformationResolver : IUserInformationResolver
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IUserRepository _userRepository;

        public UserInformationResolver(IHttpContextAccessor contextAccessor, IUserRepository userRepository)
        {
            _contextAccessor = contextAccessor;
            _userRepository = userRepository;
        }



        public async Task<UserInfo> GetUserInformation(CancellationToken token)
        {
            var user = _contextAccessor?.HttpContext?.User;

            var Id = user?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var info = new UserInfo
            {
                IsActive = bool.TryParse(user?.FindFirst("IsActive")?.Value, out var active) && active,
            };
            if (!Guid.TryParse(Id, out var userId))
                throw new ApplicationException("Invalid user id");

            info.UserId = userId;
            info.UserName = await _userRepository.GetUserNameAsync(userId, token);

            if (user != null)
            {
                foreach (var claim in user.Claims)
                {
                    info.Claims[claim.Type] = claim.Value;
                }
            }

            return info;
        }
    }
}
