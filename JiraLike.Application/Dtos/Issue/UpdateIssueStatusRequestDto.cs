namespace JiraLike.Application.Dto.Issue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class UpdateIssueStatusRequestDto
    {
        public string Status { get; set; } = null!;
    }

}
