namespace JiraLike.Application.Dto
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class IssueResponseDto
    {
        public Guid Id { get; set; }
        public string Key { get; set; } = null!;
        public string Type { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Status { get; set; } = null!;
        public string? AssigneeName { get; set; }
    }

}
