using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraLike.Application.Dto.Project
{
    public class ProjectResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Key { get; set; } = null!;
        public string Status { get; set; } = null!;

        public Guid CreatedBy { get; set; }

        public string CreatedbyUserName { get; set; } = null;

        public DateTime CreatedAt { get; set; }
    }

}
