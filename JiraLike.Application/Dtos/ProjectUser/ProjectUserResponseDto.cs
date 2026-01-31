namespace JiraLike.Application.Dto.ProjectUser
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ProjectUserResponseDto
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string RoleName { get; set; } = null!;
    }

}
