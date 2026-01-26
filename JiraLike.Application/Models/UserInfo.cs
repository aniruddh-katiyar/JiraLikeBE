namespace JiraLike.Application.Models
{
    using System.Collections.Generic;

    public class UserInfo
    {
        public string? Id { get; set; }
        public bool IsActive { get; set; }
        public Dictionary<string, string?> Claims { get; set; } = new();
    }
}
