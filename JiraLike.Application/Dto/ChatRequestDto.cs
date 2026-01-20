namespace JiraLike.Application.Dto
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ChatRequestDto
    {
        public Guid ProjectId { get; set; }
        public string Question { get; set; } = null!;
    }

}
