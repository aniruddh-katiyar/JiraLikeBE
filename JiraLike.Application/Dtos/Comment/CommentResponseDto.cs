namespace JiraLike.Application.Dtos.Comment
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CommentResponseDto
    {
        public string Content { get; set; } = string.Empty;

        public DateTime CommentDate { get; set; }

        public string UserName = string.Empty;

        public Guid CommentId { get; set; }

    }
}
