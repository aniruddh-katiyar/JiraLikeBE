namespace JiraLike.Application.Dto
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CreateIssueRequestDto
    {
        public string Type { get; set; } = null!;   // Epic, Story, Task, Bug
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public Guid? ParentIssueId { get; set; }
    }

}
