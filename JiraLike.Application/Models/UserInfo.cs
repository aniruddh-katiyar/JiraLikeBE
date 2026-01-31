namespace JiraLike.Application.Models
{
    using System.Collections.Generic;

    public class UserInfo
    {
        public Guid UserId{ get; set; }
        public bool IsActive { get; set; }
        public Dictionary<string, string?> Claims { get; set; } = new();

        public string UserName { get; set; } = null!;
    }
}
