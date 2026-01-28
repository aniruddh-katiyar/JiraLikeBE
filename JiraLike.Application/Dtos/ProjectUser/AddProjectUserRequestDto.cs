namespace JiraLike.Application.Dto.ProjectUser
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class AddProjectUserRequestDto
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
    }

}
