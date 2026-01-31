namespace JiraLike.Application.Dto.Auth
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class LogoutRequestDto
    {
        public string RefreshToken { get; set; } = null!;
    }

}
