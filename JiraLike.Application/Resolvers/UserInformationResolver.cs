namespace JiraLike.Application.Resolvers
{
    using JiraLike.Application.Models;
    using Microsoft.AspNetCore.Http;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Threading.Tasks;



    public class UserInformationResolver : IUserInformationResolver
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public UserInformationResolver(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }



        public Task<UserInfo> GetUserInformation()
        {
            var user = _contextAccessor?.HttpContext?.User;

            var info = new UserInfo
            {
                Id = user?.FindFirst(ClaimTypes.NameIdentifier)?.Value,
                IsActive = bool.TryParse(user?.FindFirst("IsActive")?.Value, out var active) && active
            };

            if (user != null)
            {
                foreach (var claim in user.Claims)
                {
                    info.Claims[claim.Type] = claim.Value;
                }
            }

            return Task.FromResult(info);
        }
    }
}
